using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
    public PlayerManager PlayerManager;
    public Health playerHealth;
    public HeartContAndOrbs DeleteROrb , DeleteBOrb , DeleteGOrb;

   // public NEWPlayerController controller;
   
    private Vector3 playerPos = Vector3.zero;
    public GameObject playerGameObject;

    public Vector3 PLAYER => playerPos;



    private void Start()
    {
        //CARGAR POSICION
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
            Debug.Log("Dato cargado, la posición es: " + playerPos);
        }

    }

    public void SaveData()
    {
        //vida
        PlayerPrefs.SetInt("_currentHp",playerHealth.CurrentHP );
        Debug.Log("La vida es: " +  playerHealth.CurrentHP );

        //posicion
        playerPos = playerGameObject.transform.position;
        PlayerPrefs.SetString("Position", JsonUtility.ToJson(playerPos));
        Debug.Log("La posición es: " + playerPos);

        //cantidad de orbes
        PlayerPrefs.SetInt("_currentOrbs", PlayerManager.ORBS);
        Debug.Log("Total de Orbes: " + PlayerManager.ORBS);

        //visibilidad de orbes
        PlayerPrefs.SetInt("Red", (DeleteROrb.RED ? 1 : 0));
        PlayerPrefs.SetInt("Blue", (DeleteBOrb.BLUE ? 1 : 0));
        PlayerPrefs.SetInt("Green", (DeleteGOrb.GREEN ? 1 : 0));

    }
   
    
    public void DeleteData()
    {
        PlayerPrefs.DeleteAll();
    }


}
