using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Events : MonoBehaviour
{
    public GameObject pauseMenu;

    void Start()
    {
        pauseMenu.SetActive(false);

    }

    public void Restart()
    {
        SceneManager.LoadScene("Level");
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene("Level");

    }

    

    public void OnDisplayPauseMenu()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void OnResumePress()
    {
        pauseMenu.SetActive(false);


        Time.timeScale = 1;
    }
}
