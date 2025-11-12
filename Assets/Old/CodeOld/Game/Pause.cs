using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{

    public GameObject PauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        PauseMenu.SetActive(false);
    }

    public void GamePause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void BackToGame()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}