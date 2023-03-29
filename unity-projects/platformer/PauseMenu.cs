using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool IsPaused = false;
    private bool death;
    public GameObject PauseMenuUI;
    public GameObject DeathScreenUI;
    public GameObject UIElements;
    // Update is called once per frame
    public void Awake()
    {
        Time.timeScale = 1f;
        IsPaused = false;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        UIElements.SetActive(true);
        Time.timeScale = 1f;
        IsPaused = false;
    }
    void Pause()
    {
        PauseMenuUI.SetActive(true);
        UIElements.SetActive(false);
        Time.timeScale = 0f;
        IsPaused = true;
    }
    public void DeathScreen(bool death)
    {
        DeathScreenUI.SetActive(death);
        Time.timeScale = 0f;
        IsPaused = true;
        UIElements.SetActive(false);
    }
    public void RestartGame()
    {
        DeathScreenUI.SetActive(false);
        SceneManager.LoadScene(1);
    }
}
