using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbes : MonoBehaviour
{
    //aca voy a llamar a las clases de los orbes

    public RedOrbDissapear Red;
    public BlueOrbDissapears Blue;
    public GreenOrbDissapears Green;

    [SerializeField] private GameObject R, B, G;
    [SerializeField] private bool RedDissapears,BlueDissapears,GreenDissapears;

    public bool RED => RedDissapears;
    public bool BLUE => BlueDissapears;
    public bool GREEN => GreenDissapears;


    private void Start()
    {
        RedDissapears = (PlayerPrefs.GetInt("Red") != 0);
        BlueDissapears = (PlayerPrefs.GetInt("Blue") != 0);
        GreenDissapears = (PlayerPrefs.GetInt("Green") != 0);

        CheckREDOrb(RED);
        CheckBLUEOrb(BLUE);
        CheckGreenOrb(GREEN);
    }

    // Update is called once per frame
    void Update()
    {
        if (Red.REDTAKEN)
        {
            R.SetActive(false);
            RedDissapears = true;
        }
        if (Blue.BLUETAKEN)
        {
            B.SetActive(false);
            BlueDissapears = true;
        }
        if(Green.GREENTAKEN)
        {
            G.SetActive(false);
            GreenDissapears = true;
        }
    }


    public void CheckREDOrb(bool val1)
    {
        RedDissapears = val1;

        if (RedDissapears)
        {

            R.SetActive(false);

        }


    }

    public void CheckBLUEOrb(bool val1)
    {
        BlueDissapears = val1;

        if (BlueDissapears)
        {

            B.SetActive(false);

        }


    }

    public void CheckGreenOrb(bool val1)
    {
        GreenDissapears = val1;

        if (GreenDissapears)
        {

            G.SetActive(false);

        }


    }

}
