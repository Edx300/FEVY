using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itsATrap : MonoBehaviour
{
    [SerializeField] private GameObject enemies;

    public void TimeToAttack()
    {
        enemies.SetActive(true);
    }

}
