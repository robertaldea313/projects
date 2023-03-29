using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public GameObject SettingsUI;
    public GameObject MainUI;

    public Slider SoundSlider;
    public Slider MusicSlider;

    public void Awake()
    {
        SoundSlider.value = GameObject.Find("AudioManager").GetComponent<AudioManager>().soundMult;
        MusicSlider.value = GameObject.Find("MusicPlayer").GetComponent<AudioSource>().volume;
    }

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

    public void Settings()
    {
        SettingsUI.SetActive(true);
        MainUI.SetActive(false);
    }

    public void Return()
    {
        SettingsUI.SetActive(false);
        MainUI.SetActive(true);
    }

    public void SoundSetting()
    {
        GameObject.Find("AudioManager").GetComponent<AudioManager>().soundMult = SoundSlider.value;
    }
    public void MusicSetting()
    {
        GameObject.Find("MusicPlayer").GetComponent<AudioSource>().volume = MusicSlider.value;
    }
}
