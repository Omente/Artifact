using System.Collections;
using TMPro;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Text;

public class EndGameController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI endGamePanel;

    private Artifact artifact;
    private TimeManager timeManager;
    private bool endGameHappend = false;
    private float timeToLoadMainMenu = 2f;
    private StringBuilder stringBuilder = new StringBuilder();
   
    

    private void Awake()
    {
        timeManager = gameObject.GetComponent<TimeManager>();
        artifact = GameObject.FindWithTag("Artifact").GetComponent<Artifact>();
        endGamePanel.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (endGameHappend)
            return;

        if(artifact.IsDead == true)
        {
            endGameHappend = true;
            StartCoroutine(LoadMainMenu());
        }
        if(timeManager.TimeToWin <= Mathf.Epsilon)
        {
            endGameHappend = true;
            StartCoroutine(LoadMainMenu());
        }

    }

    private IEnumerator LoadMainMenu()
    {
        stringBuilder.Clear();

        if (artifact.IsDead)
        {
            stringBuilder.Append("Artifact was destroyed.");
        }
        else
        {
            stringBuilder.Append("You managed to save artifact");
        }

        endGamePanel.gameObject.SetActive(true);
        endGamePanel.text = stringBuilder.ToString();

        yield return new WaitForSecondsRealtime(timeToLoadMainMenu);

        SceneManager.LoadScene(0);
    }
}
