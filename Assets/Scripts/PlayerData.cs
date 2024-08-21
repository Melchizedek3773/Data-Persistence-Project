using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static PlayerData Instance;
    public int Scores;
    public string Name;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(Instance);
        LoadScore();
    }

    [System.Serializable]
    class SaveData
    {
        public int Scores;
        public string Name;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.Scores = Scores;
        data.Name = Name;


        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savedata.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savedata.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            Scores = data.Scores;
            Name = data.Name;
        }
    }
}
