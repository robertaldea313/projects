using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
    GameObject DeathMenu;
    GameObject GameUI;
    GameObject Canvas;
    GameObject player;
    private void Start()
    {
        Canvas = GameObject.Find("Canvas");
        player = GameObject.Find("Player");
        DeathMenu = Canvas.transform.Find("DeathMenu").gameObject;
        GameUI = Canvas.transform.Find("UI").gameObject;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("PlayerDeath");
            player.SetActive(false);
            DeathMenu.SetActive(true);
            GameUI.SetActive(false);
            Time.timeScale = 0;
        }
        

    }
}
