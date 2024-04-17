using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GreenOrbDissapears : MonoBehaviour
{
    [SerializeField] private bool _isInRange;
    public UnityEvent _interact;

    private bool GreenTaken;

    public bool GREENTAKEN => GreenTaken;

    void Update()
    {
        if (_isInRange)
        {
            _interact.Invoke();
            GreenTaken = true;


        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Player":

                _isInRange = true;

                break;
        }


    }

    private void OnTriggerExit(Collider other)
    {
        switch (other.tag)
        {
            case "Player":

                _isInRange = false;
                //other.gameObject.GetComponent<PlayerManager>().DeNotifyPlayer();
                //Debug.Log("Player is out of range");

                break;



        }
    }

}
