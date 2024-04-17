using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RedOrbDissapear : MonoBehaviour
{
    [SerializeField] private bool _isInRange;
    public UnityEvent _interact;
    //[SerializeField] private GameObject Orb;

    private bool RedTaken;

    public bool REDTAKEN => RedTaken;

    // Update is called once per frame
    void Update()
    {
        if (_isInRange)
        {
            _interact.Invoke();
            RedTaken = true;
            

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
