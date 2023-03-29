using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
  public void PlayGame()
    {
        SceneManager.LoadScene(1);
        PauseMenu.IsPaused = false;
        Time.timeScale = 1;
    }
  public void QuitGame()
    {
        Application.Quit();

    }
 public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }   
}
