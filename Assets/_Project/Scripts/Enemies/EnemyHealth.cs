using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] private float _EnemyHp = 10;

    public void TakeDamage(float damage)
    {
        _EnemyHp -= damage;

        if(_EnemyHp <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        GameObject.Destroy(gameObject);
    }

}
