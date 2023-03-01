using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfHealth : MonoBehaviour
{
    [SerializeField] private GameObject healthUI;
    [SerializeField] private float scale;
    [SerializeField] private int maxHelat = 100;

    private int currentHealth;

    private void Awake()
    {
        currentHealth = maxHelat;
    }

    public void TakeDamage(int ammount)
    {
        currentHealth -= ammount;

        scale = (float)currentHealth / maxHelat;

        healthUI.transform.localScale = new Vector3(scale, healthUI.transform.localScale.y, transform.localScale.z);

        if (currentHealth <= 0) Destroy(gameObject);
    }
}
