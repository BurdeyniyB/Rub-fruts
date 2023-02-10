using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevelManagerSound : MonoBehaviour
{
    private int audio;
    void Start()
    {
        audio = PlayerPrefs.GetInt("Level manager click");

        if(audio == 1)
        {
          PlayerPrefs.SetInt("Level manager click", 0);

          PlayerPrefs.SetInt("Click", 1);
        }
    }
}
