using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool IsPaused = false;
    public GameObject PauseMenuUI;
    public GameObject DeathMenuUI;
    public GameObject ScoreUI;
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
        ScoreUI.SetActive(true);
        Time.timeScale = 1f;
        IsPaused = false;
        GameObject.Find("rotationPoint").GetComponent<PlayerShoot>().enabled = true;
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        ScoreUI.SetActive(false);
        Time.timeScale = 0f;
        IsPaused = true;
        GameObject.Find("rotationPoint").GetComponent<PlayerShoot>().enabled = false;
    }

    public void Death()
    {
        Time.timeScale = 0f;
        IsPaused = true;
        DeathMenuUI.SetActive(true);
        ScoreUI.SetActive(false);
        GameObject.Find("rotationPoint").GetComponent<PlayerShoot>().enabled = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

}
