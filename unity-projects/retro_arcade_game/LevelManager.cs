using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int Level;
    public void LoadLevel()
        {
            SceneManager.LoadScene(Level+1);
        }
}
