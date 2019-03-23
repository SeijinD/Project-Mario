using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class Data_Management : MonoBehaviour
{
    public static Data_Management datamanagement;

    public int hightScore;

    void Awake()
    {
        if (datamanagement == null)
        {
            DontDestroyOnLoad(gameObject);
            datamanagement = this;
        }
        else if (datamanagement != this)
            Destroy(gameObject);
    }

    public void SaveData()
    {
        BinaryFormatter BinForm = new BinaryFormatter(); //create a bin formatter
        FileStream file = File.Create(Application.persistentDataPath + "/gameInfo.dat"); //create file
        gameData data = new gameData(); //creates container for data
        data.hightscore = hightScore;
        BinForm.Serialize(file, data); //serializes
        file.Close(); //closes file
    }

    public void LoadData()
    {
        if (File.Exists(Application.persistentDataPath + "/gameInfo.dat"))
        {
            BinaryFormatter BinForm = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gameInfo.dat", FileMode.Open);
            gameData data = (gameData)BinForm.Deserialize(file);
            file.Close();
            hightScore = data.hightscore;
        }
    }
}

[Serializable]
class gameData
{
    public int hightscore;
}
