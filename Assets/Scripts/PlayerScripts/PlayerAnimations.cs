using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private Sprite[] animSprite;

    private float timeTreshold = 0.1f;
    private float timer;
    private int state = 0;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(Time.time > timer)
        {
            spriteRenderer.sprite = animSprite[state % animSprite.Length];
            state++;
            timer = Time.time + timeTreshold;
        }
    }

}
