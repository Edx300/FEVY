using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullets : MonoBehaviour
{

    public GameObject projectile;
  

    private void OnTriggerEnter(Collider other)
    {

        switch (other.tag)
        {
            case "Player":
                
                Destroy(projectile,.5f);

                break;

            case "world":

                Destroy(projectile,1f);

                break;



        }
    }


}
