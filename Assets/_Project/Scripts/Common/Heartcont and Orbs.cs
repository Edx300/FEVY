using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HeartContAndOrbs : MonoBehaviour
{
    //public PlayerManager PlayerManager;

    public bool _isInRange;
    public UnityEvent _interactAction;

    //[SerializeField] public bool _needsToDissapear;
    [SerializeField] private GameObject _gameObj;


    //[SerializeField] public bool Red, Blue, Green, none; //para identificar individualmente cual es cual

    //[SerializeField] private bool Red1, Blue1, Green1;//para eliminar
    //private bool r4 = false;


    //public bool RED => Red1;
    //public bool BLUE => Blue1;
    //public bool GREEN => Green1;

   // [SerializeField] private GameObject _BlueOrb, _RedOrb, _GreenOrb;

    private void Start()
    {
       // Red1 = (PlayerPrefs.GetInt("Red") != 0);
       // Blue1 = (PlayerPrefs.GetInt("Blue") != 0);
       // Green1 = (PlayerPrefs.GetInt("Green") != 0);

        //Debug.Log("r1" + Red1);
        //Debug.Log("b1" + Blue1);
        //Debug.Log("g1" + Green1);
        //CheckREDOrb(RED);
        //CheckBLUEOrb(BLUE);
        //CheckGreenOrb(GREEN);
        
    }

    void Update()
    {
        if (_isInRange)
        {
            _interactAction.Invoke();
             Destroy(_gameObj);
      
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
    /*
    public void CheckREDOrb(bool val1)
    {
        Red1 = val1;

         if (Red1)
        {

            _RedOrb.SetActive(false);

        }
        

    }

    public void CheckBLUEOrb(bool val1)
    {
        Blue1 = val1;

        if (Blue1)
        {

            _BlueOrb.SetActive(false);

        }


    }

    public void CheckGreenOrb(bool val1)
    {
        Green1 = val1;

        if (Green1)
        {

            _GreenOrb.SetActive(false);

        }


    }

    */


}
