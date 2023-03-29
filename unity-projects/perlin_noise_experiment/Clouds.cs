using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour
{
    public int width = 256;
    public int height = 256;

    public float scale = 20;

    private float offsetX;
    private float offsetY;

    public float delay = 1f;

    void Start()
    {

        offsetX = Random.Range(0, 1000);
        offsetY = Random.Range(0, 1000);

        Renderer rend = GetComponent<Renderer>();
        rend.material.mainTexture = GenerateTexture();
    }

    void FixedUpdate()
    {
        if (delay>0)
        {
            delay -= 0.1f;
        }
        else{
            offsetX += 1;
            offsetY += 1;
            Renderer rend = GetComponent<Renderer>();
            rend.material.mainTexture = GenerateTexture();

            delay = 1;
        }

    }


    Texture2D GenerateTexture()
    {
        Texture2D texture = new Texture2D(width, height);

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Color color = GenerateColor(x, y);
                texture.SetPixel(x, y, color);
            }
        }


        texture.Apply();
        return texture;
    }

    Color GenerateColor(int x, int y)
    {
        float size = scale;

        float xCoord = (float)x / width * scale +offsetX;
        float yCoord = (float)y / height * scale + offsetY;

        float sample = 0;
        
        while(size >= 1)
        {
            float sizeX = xCoord / size;
            float sizeY = yCoord / size;

            sample = sample + Mathf.PerlinNoise( sizeX, sizeY ) * size;
            size =size / 2;
        }
        
        return new Color(1.1f - sample / scale+0.5f, 1f - sample / scale+0.5f, 1f);
    }    
}
