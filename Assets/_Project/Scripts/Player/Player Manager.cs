using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] public PlayerAttack playerAttack;
    [SerializeField] public NEWPlayerController controller;
    [SerializeField] public GameObject _door;
    public GameObject icon;

    private int _adquiredOrbs = 0;

    public bool _checkAttack;
    public bool _checkRes;

    public int ORBS => _adquiredOrbs;

    private void Start()
    {
        _adquiredOrbs = PlayerPrefs.GetInt("_currentOrbs", 0);
        ChangeAmountofOrbs(ORBS);
    }
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
            checkDoor();
        }
    }

    public void AttackImprovement()
    {
        playerAttack._attackPower += 5f;
        _checkAttack = true;
      
    }
    public void ResistanceImprovement()
    {
        controller._resistanceloose = 3f;
        _checkRes = true;
    }




    public void ChangeAmountofOrbs(int val)
    {

        _adquiredOrbs = val;
        Debug.Log("orbes: " + val);

        if(val >= 3)
        {
            checkDoor();
        }
       
    }

    private void checkDoor()
    {
        //needs to open door
        Debug.Log("ya tienes los 3! La puerta se ha abierto");
        _door.SetActive(false);
    }

}
