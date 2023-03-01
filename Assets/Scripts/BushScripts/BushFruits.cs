using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushFruits : MonoBehaviour
{
    [SerializeField] private int[] amountPerType;
    [SerializeField] private float[] respawnTime;

    private bool hasFruits;
    public bool HasFruit { get { return hasFruits; } }
    private bool isAlive = true;
    private float timer;
    private BushVisual bushVisual;

    private void Awake()
    {
        bushVisual = GetComponent<BushVisual>();

        if(Random.Range(0,2) == 0)
        {
            hasFruits = false;
            timer = Time.time + respawnTime[(int)bushVisual.BushVariant];
        }
        else
        {
            hasFruits = true;
            bushVisual.ShowFruits();
        }
        
    }

    private void Update()
    {
        if(Time.time > timer && isAlive)
        {
            hasFruits = true;
            bushVisual.ShowFruits();
        }
    }

    public int HarvestFruits()
    {
        if(hasFruits)
        {
            hasFruits = false;
            bushVisual.HideFruits();
            timer = Time.time + respawnTime[(int)bushVisual.BushVariant];
            return amountPerType[(int)bushVisual.BushVariant];
        }
        else
        {
            return 0;
        }
    }

    public void EatBushFruits()
    {
        bushVisual.HideFruits();
        bushVisual.SetToDry();
        hasFruits = false;
        isAlive = false;
        gameObject.GetComponent<BushVisual>().enabled = false;
    }


}
