using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    int scoreVal = 0;
    public int scoreInc;
    int scoreMult = 1;
    public Text text;
    public Text endText;

    public float comboMaxTime;
    float comboTimer;
    bool combo = false;
    public Text comboText;
    public void ScoreIncrease()
    {
        scoreVal += scoreInc * scoreMult;
        text.text = scoreVal.ToString();
        endText.text = scoreVal.ToString();
        scoreMult += 1;
        comboText.text = "X" + scoreMult; 
        comboTimer = comboMaxTime;
        combo = true;
    }

    private void Update()
    {
        if(comboTimer > 0)
        {
            comboTimer -= Time.deltaTime;
        }
        else
            if(comboTimer<=0 && combo)
        {
            combo = false;
            scoreMult = 1;
            comboText.text = "";
        }
    }
}
