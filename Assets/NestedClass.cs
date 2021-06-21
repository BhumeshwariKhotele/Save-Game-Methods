using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class NestedClass : MonoBehaviour
{
    // Start is called before the first frame update
    string playerName = "Bhoomi";
    int playerAge = 24;
    int playerScore = 100;
    string playerLocation = "Bhandara";
   
    [System.Serializable]
    public class DataDemo
    {
      public  string playerName;
       public int playerAge;
        public int playerScore;
        public string playerLocation; 

        public DataDemo(string playerName, int playerAge, int playerScore,string playerLocation)
        {

            this.playerName = playerName;
            this.playerAge = playerAge;
            this.playerScore = playerScore;
            this.playerLocation = playerLocation;
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SavePlayerData();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            GetPlayerData();
        }
    }

    void SavePlayerData()
    {
        string filepath = UnityEngine.Application.persistentDataPath + "/NestedDataDemo.file";
        FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate);
        BinaryFormatter bw = new BinaryFormatter();
        DataDemo obj = new DataDemo(playerName, playerAge, playerScore,playerLocation);
        bw.Serialize(fs, obj);
        fs.Close();

    }

    void GetPlayerData()
    {
        string filepath = UnityEngine.Application.persistentDataPath + "/NestedDataDemo.file";
        FileStream fs = new FileStream(filepath, FileMode.Open);
        BinaryFormatter bw = new BinaryFormatter();
        DataDemo data= bw.Deserialize(fs)as DataDemo;
        print("Name: "+data.playerName+"Age:" +data.playerAge+"Score"+data.playerScore+"Location"+data.playerLocation);
        fs.Close();
    }
}
