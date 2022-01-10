using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int score;
    public Text scoreTxt;
    public Text recordTxt;

    private void Awake()
    {
        score = 0;
        recordTxt.text = "Record: " + PlayerPrefs.GetInt("Record").ToString();
    }

    private void Update()
    {
        scoreTxt.text = score.ToString();
    }

    public void AddScore()
    {
        score++;
        if (score > PlayerPrefs.GetInt("Record"))
        {
            PlayerPrefs.SetInt("Record", score);
        }
    }
}
