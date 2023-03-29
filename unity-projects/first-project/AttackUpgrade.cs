using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackUpgrade : MonoBehaviour
{
    GameObject player;
    public GameObject gun;
    private int upgradeChance;
    private int upgradeMax =2;

    void Start()
    {
    }
    public void UpgradeChooser()
    {
        upgradeChance = Random.Range(0,upgradeMax);
        if(upgradeChance  == 0)
            gun.GetComponent<Gun>().ChangeBullet(1,0);
        else
        {
           gun.GetComponent<Gun>().ChangeBullet(0,0.75f); 
        }    
        Debug.Log("Working");
    }


}
