using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HeartContAndOrbs : MonoBehaviour
{
    //public PlayerManager PlayerManager;

    public bool _isInRange;
    public UnityEvent _interactAction;


    

    [SerializeField] public bool _needsToDissapear;
    [SerializeField] public GameObject _gameObj;

    void Update()
    {
        if (_isInRange)
        {
            _interactAction.Invoke();
            
                if (_needsToDissapear)
                {
                  
                    Destroy(_gameObj);
                    
                }
                
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
                other.gameObject.GetComponent<PlayerManager>().DeNotifyPlayer();
                //Debug.Log("Player is out of range");

                break;



        }
    }


}
