using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject icon;
    public int _adquiredOrbs;
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
}
