using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public static bool _isPaused = false;
    public GameObject PauseWindow;
    public GameObject PlayWindow;

    public void Awake()
    {
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(_isPaused)
            {
                Resume();
            }
            else
            {
                PauseActive();
            }
        }
    }

     void PauseActive()
    {
        //GameManager.Instance.ChangeSpeed(0);
        PauseWindow.SetActive(true);
        PlayWindow.SetActive(false);
        Time.timeScale = 0f;
        _isPaused = true;
    }

     public void Resume()
    {
        //GameManager.Instance.ChangeSpeed(1);
        PauseWindow.SetActive(false);
        PlayWindow.SetActive(true);
        Time.timeScale = 1f;
        _isPaused = false;
    }
    
}
