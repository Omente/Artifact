using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;

public class PlayerBackpack : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI backPackInfoText;

    private int maxNumberOfFruitsToStore = 50;
    public int MaxNumberOfFruitsToStore { get { return maxNumberOfFruitsToStore; } }
    private int currentNumerOfFruits = 0;
    public int CurrentNumberOfFruits { get { return currentNumerOfFruits; } }
    private StringBuilder stringBuilderBackpackInfo;

    private void Awake()
    {
        stringBuilderBackpackInfo = new StringBuilder();
    }

    private void Start()
    {
        SetBackpackInfoText(currentNumerOfFruits);
    }


    public void AddFruits(int amount)
    {
        currentNumerOfFruits += amount;
        if (currentNumerOfFruits > maxNumberOfFruitsToStore) currentNumerOfFruits = maxNumberOfFruitsToStore;
        SetBackpackInfoText(currentNumerOfFruits);
    }

    public int TakeFruits()
    {
        int takenFruits = currentNumerOfFruits;
        currentNumerOfFruits = 0;
        SetBackpackInfoText(currentNumerOfFruits);

        return takenFruits;
    }

    void SetBackpackInfoText(int ammount)
    {
        stringBuilderBackpackInfo.Clear();
        stringBuilderBackpackInfo.Append($"Backpack: {ammount}/{maxNumberOfFruitsToStore}");
        backPackInfoText.text = stringBuilderBackpackInfo.ToString();
    }
}
