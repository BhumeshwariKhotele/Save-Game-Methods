using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json.Linq;

public class JSONscript : MonoBehaviour
{
    public string pname;
    public int age;
    public string[] friends;
    public string[] places;
    //public string[] friend;
    // Start is called before the first frame update
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
            getPlayerData();
        }
    }
    void SavePlayerData()
    {
        string filepath = Application.persistentDataPath + "/JSONDemo.file";

        JObject jobj = new JObject();
        jobj.Add("componentName", this.pname);

        JObject jdataDemo = new JObject();
        jobj.Add("data", jdataDemo);
        jdataDemo.Add("_name", "Bhoomi");
        jdataDemo.Add("_age", this.age);

        JArray jarraydata = JArray.FromObject(friends);
        jdataDemo.Add("friends", jarraydata);

        JArray jarrayplaces = JArray.FromObject(places);
        jdataDemo.Add("places", jarrayplaces);

        StreamWriter sw = new StreamWriter(filepath);
        sw.WriteLine(jobj.ToString());

        sw.Close();
    }
    void getPlayerData()
    {
        string filepath = Application.persistentDataPath + "/JSONDemo.file";
        StreamReader sr = new StreamReader(filepath);
        string data = sr.ReadToEnd();
        sr.Close();
        print(data);

        JObject jsonObj = JObject.Parse(data);
        pname = jsonObj["componentName"].Value<string>();
        age = jsonObj["data"]["_age"].Value<int>();
        friends = jsonObj["data"]["friends"].ToObject<string[]>();
        places = jsonObj["data"]["places"].ToObject<string[]>();
    }
}
