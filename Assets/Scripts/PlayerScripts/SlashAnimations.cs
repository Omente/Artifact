using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashAnimations : MonoBehaviour
{
    [SerializeField] private int damage = 35;
    [SerializeField] private float timeTreashold = 0.5f;
    [SerializeField] private Sprite[] slahSprites;

    private int state;
    private float timer;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(Time.time > timer)
        {
            if (state == slahSprites.Length)
            {
                Destroy(gameObject);
                return;
            }
            else
            {
                spriteRenderer.sprite = slahSprites[state];
                state++;
                timer = Time.time + timeTreashold;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Wolf"))
        {
            collision.gameObject.GetComponent<WolfHealth>().TakeDamage(damage);
        }
    }
}
