using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SaveText : MonoBehaviour
{

    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TMP_Text text;
    [SerializeField] private Button saveButton;

    private Vector3 playerPos = Vector3.zero;
    public GameObject player;

    private string textToSave;

    void Start()
    {

        text.text = textToSave = PlayerPrefs.GetString("Text", "No Save Data"); //esta unica linea hace lo mismo que todas las lineas comentadas de abajo



        var tempPos = PlayerPrefs.GetString("PlayerPos", "Error");
        if (tempPos.Equals("Error"))
        {
            playerPos = player.transform.position;
            PlayerPrefs.SetString("PlayerPos", JsonUtility.ToJson(playerPos));
        }
        else
        {
            playerPos = JsonUtility.FromJson<Vector3>(tempPos);
            player.transform.position = playerPos;
        }




        saveButton.onClick.AddListener(SaveButton); //aquí es una linea de codigo que remplaza el llamar al boton en unity


        //if(PlayerPrefs.HasKey("Text"))
        //  {
        //      textToSave = PlayerPrefs.GetString("Text");
        //      text.text = textToSave;
        //  } 
        //else
        //  {
        //      //textToSave = PlayerPrefs.GetString("Text", "No save Data"); extra
        //      //PlayerPrefs.SetString("Text", "No Save Data");
        //      //textToSave = PlayerPrefs.GetString("Text"); (esto es 
        //      //text.text = textToSave;
        //  }
    }

    public void SaveButton()
    {
        if (!string.IsNullOrEmpty(inputField.text) ||
            !string.IsNullOrWhiteSpace(inputField.text))
        {
            textToSave = inputField.text;
            PlayerPrefs.SetString("Text", textToSave);
            text.text = textToSave;
        }
        playerPos = player.transform.position;
        PlayerPrefs.SetString("PlayerPos", JsonUtility.ToJson(playerPos));
    }
}