using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushVisual : MonoBehaviour
{
    [SerializeField] private Sprite[] bushSprite, fruitSprite, drySprite;
    [SerializeField] private SpriteRenderer[] fruitsRenderers;


    private float hideTimePerFruit = 0.2f;
    public float HideTimePerFruit { get { return hideTimePerFruit; } set { hideTimePerFruit = value; } }
    private SpriteRenderer spriteRenderer;
    private BushVariant bushVariant;
    public BushVariant BushVariant { get { return bushVariant; } }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        bushVariant = (BushVariant)Random.Range(0, bushSprite.Length);
        spriteRenderer.sprite = bushSprite[(int)bushVariant];
        if(Random.Range(0, 2) == 1)
        {
            spriteRenderer.flipX = true;
        }

        for(int i = 0; i < fruitsRenderers.Length; i++)
        {
            fruitsRenderers[i].sprite = fruitSprite[(int)bushVariant];
            fruitsRenderers[i].enabled = false;
        }
    }

    public void SetToDry()
    {
        spriteRenderer.sprite = drySprite[(int)bushVariant];
    }

    IEnumerator _HideFruits(float time, int index)
    {
        yield return new WaitForSeconds(time);
        fruitsRenderers[index].enabled = false;
    }

    public void HideFruits()
    {
        float waitTimeForFruits = hideTimePerFruit;

        for(int i = 0; i < fruitsRenderers.Length; i++)
        {
            StartCoroutine(_HideFruits(waitTimeForFruits, i));
            waitTimeForFruits += hideTimePerFruit;
        }
    }

    public void ShowFruits()
    {
        for(int i = 0; i < fruitsRenderers.Length; i++)
        {
            fruitsRenderers[i].enabled = true;
        }
    }
}
