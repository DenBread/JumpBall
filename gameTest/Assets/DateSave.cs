using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DateSave : MonoBehaviour
{
    public int record;


    private void Start()
    {
        LoadGame();
    }

    public void SaveGame()
    {
        
    }

    public void LoadGame()
    {
        record = PlayerPrefs.GetInt("Record");
    }

    public void ResetDate()
    {

    }

    public void SaveRecord()
    {

    }
}
