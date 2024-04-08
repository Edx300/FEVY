using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] public PlayerAttack playerAttack;
    [SerializeField] public NEWPlayerController controller;
    public GameObject icon;
    public int _adquiredOrbs = 0;

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

    public void AttackImprovement()
    {
        playerAttack._attackPower += 5f;
      
    }
    public void ResistanceImprovement()
    {
        controller._resistanceloose = 3f;
    }

}
