using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject icon;
    public int _adquiredOrbs = 0;
    public bool _attackGetsPowerUp;
    public bool _resistanceGetsPowerUp;

    public void NotifyPlayer()
    {
        icon.SetActive(true);
    }

    public void DeNotifyPlayer()
    {
        icon.SetActive(false);
    }

    public void gotAnOrb()
    {
        _adquiredOrbs++;

        Debug.Log("Cantidad de orbes:" + _adquiredOrbs);

        if (_adquiredOrbs >= 3)
        {
            //needs to open door
            Debug.Log("ya tienes los 3! La puerta se ha abierto");
        }
    }

}
