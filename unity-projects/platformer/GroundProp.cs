using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundProp : MonoBehaviour
{
    public float MinVar;
    public float MaxVar;
    public float SizeVar;
    private float score;
    void Start()
    {
        score = Score.playerPoints;
        transform.localScale=new Vector3(5 - Random.Range(0,SizeVar), transform.localScale.y, transform.localScale.z);
        transform.rotation= Quaternion.Euler(0, 0, Random.Range(MinVar,MaxVar));
        if((score + 1) % 10 ==0)
            ColorChange(true);
        else 
            ColorChange(false);   
    }
    public void ColorChange(bool tenth)
    {
        if(tenth)
            this.GetComponent<Renderer>().material.SetColor("_Color", new Vector4(0.06728373f,0.2903571f,0.5283019f,1));
        else
        {
            this.GetComponent<Renderer>().material.SetColor("_Color", new Vector4(0.05700427f,0.1428489f,0.1981132f,1));    
        }    
    }



}
