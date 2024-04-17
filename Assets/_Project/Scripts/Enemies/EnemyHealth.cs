using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private Animator _anim;
    [SerializeField] private float _EnemyHp = 10;
    public GameObject _item;
    public Transform _enemyTransform;

    [SerializeField] private ParticleSystem _enemyParticle;

    public void TakeDamage(float damage)
    {
        _anim.SetTrigger("Hurt");
        _EnemyHp -= damage;

        if(_EnemyHp <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        Vector3 position = _enemyTransform.position;
        GameObject.Destroy(gameObject);
        _enemyParticle = Instantiate(_enemyParticle, position, Quaternion.identity);
        _enemyParticle.Play();
        DropItem();


    }


    void DropItem()
    {
        Vector3 position = _enemyTransform.position;
        GameObject heart = Instantiate(_item, position, Quaternion.identity);
        heart.SetActive(true);
        Destroy(heart,10f);
    }

}
