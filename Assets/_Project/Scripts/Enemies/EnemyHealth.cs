using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] public float _EnemyHp = 10;
    public GameObject _item;
    public Transform _enemyTransform;

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
        DropItem();


    }


    void DropItem()
    {
        Vector3 position = _enemyTransform.position;
        GameObject heart = Instantiate(_item, position, Quaternion.identity);
        Destroy(heart,10f);
    }

}
