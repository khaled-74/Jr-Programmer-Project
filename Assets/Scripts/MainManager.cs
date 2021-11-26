using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    public Color TeamColor; // new variable declared

    private void Awake()
    {
        LoadColor();


        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    //1-creating class
    [System.Serializable]
    class SaveData
    {
        public Color TeamColor;
    }
    public void SaveColor()
    {
        //2-Creating Object
        SaveData data = new SaveData();
        data.TeamColor = TeamColor;

        //3-Adding JasonUtility class
        string json = JsonUtility.ToJson(data);

        //4-write a string to a file
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    //Load color 
    public void LoadColor()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            TeamColor = data.TeamColor;
        }

    }

}
