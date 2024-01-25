using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class MainSettings : MonoBehaviour
{
    private TMP_InputField nameInput;
    public string nickName;

    public int highScore;
    public string highScoreName;
    private void Start()
    {
        nameInput = GameObject.FindAnyObjectByType<TMP_InputField>().GetComponent<TMP_InputField>();
    }

    public void HighScoreUpdate(int newPoint, string newName)
    {
        if(newPoint > highScore)
        {
            Savedata data = new Savedata();
            data.highScore = newPoint;
            data.highScoreName = newName;
            string json = JsonUtility.ToJson(data);
            File.WriteAllText(Application.persistentDataPath + "/savedata.json", json);
            highScore = newPoint;
            highScoreName = newName;
        }
    }

    public (int,string) LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savedata.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            Savedata newdata = JsonUtility.FromJson<Savedata>(json);
            if (newdata != null)
            {
                highScore = newdata.highScore;
                return (newdata.highScore, newdata.highScoreName);
            }
            else
            {
                return (0, "");
            }
        }
        else
        {
            return (0,"");
        }

    }
    public void ButtonControl(string id)
    {
        if (id == "Start")
        {
            nickName = nameInput.text;
            DontDestroyOnLoad(this);
            SceneManager.LoadScene(1);
        }

        if (id == "Quit")
        {
            Application.Quit();
        }
    }
    [System.Serializable]
    class Savedata
    {
        public int highScore;
        public string highScoreName;
    }
}
