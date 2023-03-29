using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{
private float WaveTimer;
    public float PauseTime;
    public float ActiveTime;
    private int WaveCounter;
    public Text WaveUI;

    bool WavePause;
    bool SpawnerActive;

    public GameObject Spawner;

    public GameObject UpgradeWindow;

    void Start()
    {
        WavePause = true;
        WaveTimer = PauseTime;
        WaveCounter = 1;
        WaveUI.text ="Wave " + WaveCounter;
    }

    void Update()
    {
        if(WaveTimer>0 && WavePause==true)
            {
                WaveTimer-=Time.deltaTime;
                Destroy(GameObject.Find("Spawner(Clone)"));
            }
    if(WaveTimer>0 && WavePause==false)
    {
        WaveTimer-=Time.deltaTime;
        if(SpawnerActive==false)
        {
            if(WaveCounter==1)
               {
                   Instantiate(Spawner, new Vector2(0,0), Quaternion.identity);
                   SpawnerActive=true;
               }
            if(WaveCounter>=2 && WaveCounter<=4)
               {
                   Instantiate(Spawner, new Vector2(0,0), Quaternion.identity);
                   Instantiate(Spawner, new Vector2(0,0), Quaternion.identity);
                   SpawnerActive=true;
               }   
        }
    }
     else
    if(WaveTimer<=0 && WavePause==false)
            {
                WaveTimer=PauseTime;
                WaveCounter+=1;
                WaveUI.text ="Wave " + WaveCounter ;
                Debug.Log(WaveCounter);
                 SpawnerActive=false;
                 WavePause =true;    
                
            }    
    }

  private void OnTriggerStay2D(Collider2D other)
     {
        if(Input.GetKey("e") && WavePause==true)
            {
                UpgradeWindow.SetActive(true);
                Debug.Log("Wave start");
            }      
    }
   public void NextWave()
   {
       UpgradeWindow.SetActive(false);
       WavePause=false;
        WaveTimer=ActiveTime;
   } 
}    