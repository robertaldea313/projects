using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static float playerPoints;
    public float ScoreStartVal;
    public Text ScoreUI;
    void Start()
    {
        playerPoints = ScoreStartVal;
        Time.timeScale = 0.9f;
    }
    public void ScoreIncrease()
    {
        playerPoints += 1;
        ScoreUI.text = "" + playerPoints;
        Time.timeScale += 0.01f;
    }

}
