using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject PauseWindow;

    public void Awake()
    {
        Time.timeScale = 1;
    }
    
    public void PauseActive()
    {
        //GameManager.Instance.ChangeSpeed(0);
        PauseWindow.SetActive(true);
    }

    public void Resume()
    {
        //GameManager.Instance.ChangeSpeed(1);
        PauseWindow.SetActive(false);
    }
    
}
