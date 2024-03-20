using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private LayerMask _enemies;
    [SerializeField] public float _maxHealthPlayer = 100;
    private float _currentHealth = default;

    

    // Start is called before the first frame update
    void Start()
    {
        _currentHealth = _maxHealthPlayer;
    }

    public void CollisionDamage()
    {
        DoDamage(10);
    }

    public void DoDamage(int damage)
    {
        
    }
}
