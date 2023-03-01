using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHarvest : MonoBehaviour
{
    [SerializeField] private float harvestTime = 0.4f;

    private bool canHarvestFruits;
    private PlayerMovment playerMovment;
    private PlayerBackpack playerBackpack;
    private AudioSource audioSource;
    private Collider2D collidedBush;
    private BushFruits hitBush;

    private void Awake()
    {
        playerMovment = GetComponent<PlayerMovment>();
        playerBackpack = GetComponent<PlayerBackpack>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Space))
        {
            TryHarvestFruits();
        }
    }

    private void TryHarvestFruits()
    {
        if (!canHarvestFruits || playerBackpack.CurrentNumberOfFruits >= playerBackpack.MaxNumberOfFruitsToStore) return;

        if(collidedBush != null)
        {
            hitBush = collidedBush.GetComponent<BushFruits>();
            if(hitBush.HasFruit)
            {
                audioSource.Play();
                playerMovment.HarvestStopMovement(harvestTime);
                playerBackpack.AddFruits(hitBush.HarvestFruits());
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Bush"))
        {
            canHarvestFruits = true;
            collidedBush = collision;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Bush"))
        {
            canHarvestFruits = false;
            collidedBush = null;
        }
    }
}
