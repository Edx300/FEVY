using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public Health playerHealth;

    public void SaveData()
    {

        PlayerPrefs.SetInt("_currentHp", playerHealth._currentHp);


    }
    
    public void LoadData()
    {
        playerHealth._currentHp = PlayerPrefs.GetInt("_currentHp");
    }

    public void DeleteData()
    {
        PlayerPrefs.DeleteAll();
    }


}
