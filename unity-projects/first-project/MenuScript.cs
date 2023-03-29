using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
  public void PlayGame()
    {
        SceneManager.LoadScene(0);
        PauseMenu.IsPaused = false;
    }
  public void QuitGame()
    {
        Application.Quit();

    }
 public void ReturnToMenu()
    {
        SceneManager.LoadScene(1);
    }   
}
