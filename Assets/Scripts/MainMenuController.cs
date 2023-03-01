using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private Canvas howToPlayCanvas;
    [SerializeField] private Canvas mainMenuCanvas;

    private const string GAMEPLAY_SCENE_NAME = "GamePlay";

    private void Start()
    {
        mainMenuCanvas.gameObject.SetActive(true);
        howToPlayCanvas.gameObject.SetActive(false);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(GAMEPLAY_SCENE_NAME);
    }

    public void ShowMainMenu()
    {
        mainMenuCanvas.gameObject.SetActive(true);
        howToPlayCanvas.gameObject.SetActive(false);
    }

    public void ShowHowToPlay()
    {
        mainMenuCanvas.gameObject.SetActive(false);
        howToPlayCanvas.gameObject.SetActive(true);
    }
}
