using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public Health playerHealth;
    public NEWPlayerController controller;
    public GameObject playerGameObject;

    public void SaveData()
    {
        //vida
        PlayerPrefs.SetInt("_currentHp",playerHealth.CurrentHP );
        Debug.Log("Dato guardado, la vida es: " +  playerHealth.CurrentHP );

        //posicion
        PlayerPrefs.SetString("Position", JsonUtility.ToJson(controller.PlayerPos));
        Debug.Log("Dato guardado, la posición es: " + controller.PlayerPos);
        //var tempPos = PlayerPrefs.GetString("PlayerPos", "Error");
        /* 
         if (tempPos.Equals("Error"))
         {
             controller.DefaultPos(controller.PlayerPos);
             PlayerPrefs.SetString("PlayerPos", JsonUtility.ToJson(controller.PlayerPos));
         }
         else
         {

             JsonUtility.FromJson<Vector3>(PlayerPrefs.GetString("Position"));

             Debug.Log("Dato guardado, la posición es: " + controller.PlayerPos);
         }
            */


    }
    
    public void LoadData()
    {
        playerHealth.ChangeHealth(PlayerPrefs.GetInt("_currentHp",100));
        Debug.Log("Dato cargado, la vida es: " + playerHealth.CurrentHP);

        controller.ChangePos(JsonUtility.FromJson<Vector3>(PlayerPrefs.GetString("Position")));
    }

    public void DeleteData()
    {
        PlayerPrefs.DeleteAll();
    }


}
