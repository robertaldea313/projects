using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeRandomizer : MonoBehaviour
{
    public float SizeMod;
    private float Size;
    void Awake()
    {
        Size=Random.Range(-SizeMod,SizeMod);
        transform.localScale +=new Vector3(Size, Size, 0);
    }

}
