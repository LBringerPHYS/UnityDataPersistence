using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainSettings : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameInput;
    public string nickName;

    public int highScore;
    public string highScoreName;
    private void Update()
    {

    }

    public void HighScoreUpdate(int newPoint, string newName)
    {
        if(newPoint > highScore)
        {
            highScore = newPoint;
            highScoreName = newName;
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
}
