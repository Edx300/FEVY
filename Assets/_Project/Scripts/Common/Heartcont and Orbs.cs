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


    [SerializeField] private bool Red, Blue, Green, none;

    [SerializeField] private GameObject _BlueOrb, _RedOrb, _GreenOrb;

    void Update()
    {
        if (_isInRange)
        {
            _interactAction.Invoke();
            
                if (_needsToDissapear)
                {
                  if(none){
                    Destroy(_gameObj);
                    } else if(Red){
                        Destroy(_RedOrb);
                    }else if(Blue) {
                    Destroy(_BlueOrb);
                }
                  else if(Green)
                {
                    Destroy(_GreenOrb);
                }
                    
                    
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
                //other.gameObject.GetComponent<PlayerManager>().DeNotifyPlayer();
                //Debug.Log("Player is out of range");

                break;



        }
    }


}
