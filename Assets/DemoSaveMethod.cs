using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoSaveMethod : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            SetPlayerData();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            GetPlayerData();
        }

    }

    void SetPlayerData()
    {
        PlayerPrefs.SetInt("PlayerAge", 25);
        PlayerPrefs.SetString("PlayerName","Bhoomi");
        PlayerPrefs.SetString("Time", "10:10:10");
        Debug.Log("Saved the player score");
    }

    void GetPlayerData()
    {
        string name = PlayerPrefs.GetString("PlayerName");
        string time = PlayerPrefs.GetString("Time");
        int score= PlayerPrefs.GetInt("Score");
        print("The player Score is " + score);
    }
}
