using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Windows;

public class AnotherMethod : MonoBehaviour
{ 
    // Start is called before the first frame update
    void Start()
    {

        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
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
        
        string filepath = Application.persistentDataPath + "/MyInformation.file";
          //StreamWriter sw = new StreamWriter(filepath);
        FileStream fs = new FileStream(filepath,FileMode.OpenOrCreate);
        print("-----------------------------");
        BinaryWriter sw = new BinaryWriter(fs);
        sw.Write(SystemInfo.deviceName);
        sw.Write(SystemInfo.systemMemorySize);
       // sw.Write(Screen.currentResolution);
       
        //sw.Write((double)time);
       // fs.Close();
        sw.Close();

    }

    void GetPlayerData()
    {
        string filepath = Application.persistentDataPath + "/MyInformation.file";
        //StreamReader sr = new StreamReader(filepath);
        FileStream fs = new FileStream(filepath, FileMode.Open);
        BinaryReader sr = new BinaryReader(fs);
        string systemName = sr.ReadString();
       // RAM = sr.ReadInt32();
        //time = ((float)sr.ReadDouble());
        //print("System Name is = "+systemName "System Memory is = "+RAM);
        fs.Close();
        sr.Close();

    }

}
