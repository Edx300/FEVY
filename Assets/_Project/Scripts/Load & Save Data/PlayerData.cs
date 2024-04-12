using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerData : MonoBehaviour
{
    public Health playerHealth;
   // public NEWPlayerController controller;
   
    public Vector3 playerPos = Vector3.zero;
    public GameObject playerGameObject;

    private void Start()
    {
        var tempPos = PlayerPrefs.GetString("PlayerPos", "Error");
        if (tempPos.Equals("Error"))
        {
            playerPos = playerGameObject.transform.position;
            PlayerPrefs.SetString("PlayerPos", JsonUtility.ToJson(playerPos));
            Debug.Log("No pudo encontrar la ubicación");
        }
        else
        {
            playerPos = JsonUtility.FromJson<Vector3>(tempPos);
            playerGameObject.transform.position = playerPos;
        }
    }

    public void SaveData()
    {
        //vida
        PlayerPrefs.SetInt("_currentHp",playerHealth.CurrentHP );
        Debug.Log("Dato guardado, la vida es: " +  playerHealth.CurrentHP );

        //posicion
        playerPos = playerGameObject.transform.position;
        PlayerPrefs.SetString("Position", JsonUtility.ToJson(playerPos));
        Debug.Log("Dato guardado, la posición es: " + playerPos);

    }
    
    public void LoadData()
    {
        playerHealth.ChangeHealth(PlayerPrefs.GetInt("_currentHp",100));
        Debug.Log("Dato cargado, la vida es: " + playerHealth.CurrentHP);


        playerGameObject.transform.position = JsonUtility.FromJson<Vector3>(PlayerPrefs.GetString("Position"));
        Debug.Log("Tu posicion es:" + playerGameObject.transform.position);
        //controller.ChangePos(JsonUtility.FromJson<Vector3>(PlayerPrefs.GetString("Position")));
    }

    public void DeleteData()
    {
        PlayerPrefs.DeleteAll();
    }


}
