using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marble : MonoBehaviour
{
    public int width = 256;
    public int height = 256;

    public float scale = 20;

    private float offsetX;
    private float offsetY;

    public float delay = 1f;

    public float xPeriod = 5.0f;
    public float yPeriod = 10.0f;

    public float turbPower = 5;

    void Start()
    {

        offsetX = Random.Range(0, 1000);
        offsetY = Random.Range(0, 1000);

        Renderer rend = GetComponent<Renderer>();
        rend.material.mainTexture = GenerateTexture();
    }

    void FixedUpdate()
    {

        //offsetX += 2/scale;
        //offsetY += 2/scale;



        if (delay > 0)
            delay -= 0.1f;
        else
        {
            delay = 1;
            xPeriod += Random.Range(0, 2);
            yPeriod += Random.Range(0, 2);
            Renderer rend = GetComponent<Renderer>();
            rend.material.mainTexture = GenerateTexture();
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

        float xCoord = (float)x / width * scale + offsetX;
        float yCoord = (float)y / height * scale + offsetY;

        float sample = 0;

        float sineVal = 0;

        while (size >= 1)
        {
            float sizeX = xCoord / size;
            float sizeY = yCoord / size;

            sample = sample + Mathf.PerlinNoise(sizeX, sizeY) * size;
            size = size / 2;
        }


        float xyvalue = (x * xPeriod) / width + (y * yPeriod) / height + turbPower * sample;
        sineVal = Mathf.Sin(xyvalue);


        return new Color(0.8f - sineVal, 0.2f, 0.2f);
    }
}
