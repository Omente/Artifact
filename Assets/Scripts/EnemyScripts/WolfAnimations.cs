using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfAnimations : MonoBehaviour
{
    [SerializeField] private float animTimeTreshold = 0.1f;
    [SerializeField] private Sprite[] wolfAnimSprites;

    private WolfAI wolfAI;

    private int state;
    private SpriteRenderer spriteRenderer;
    private float timer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        wolfAI = GetComponent<WolfAI>();
    }

    private void Update()
    {
        if (wolfAI.IsMoving)
        {
            if (Time.time > timer)
            {
                spriteRenderer.sprite = wolfAnimSprites[state % wolfAnimSprites.Length];
                state++;

                timer = Time.time + animTimeTreshold;
            }
        }
        else
        {
            spriteRenderer.sprite = wolfAnimSprites[0];
            spriteRenderer.flipX = wolfAI.Left;
        }

    }

}
