using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;

public class TimeManager : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI timerText;

    private bool gameOver = false;
    private float timeToWin = 300f;
    private GameObject artifact;
    private StringBuilder stringBuilder;

    private void Awake()
    {
        artifact = GameObject.FindWithTag("Artifact");
        stringBuilder = new StringBuilder();
    }

    private void Update()
    {
        if (gameOver || !artifact) return;

        timeToWin -= Time.deltaTime;

        if(timeToWin <= 0f)
        {
            timeToWin = 0f;
            gameOver = true;
            Destroy(artifact);

            //show win panel
        }

        DisplayTime((int)timeToWin);
    }

    private void DisplayTime(int time)
    {
        stringBuilder.Clear();

        stringBuilder.Append($"Time Remaining: {time}");
        timerText.text = stringBuilder.ToString();
    }

}
