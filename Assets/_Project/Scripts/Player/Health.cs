using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHp = 100;
    [SerializeField] private int _currentHp = default;
    [SerializeField] private UnityEvent _onDie = new();

    public HealthBarScript healthBar;

    private void Start()
    {
        _currentHp = _maxHp;
        healthBar.SetMaxHealth(_maxHp);
    }

    public void CollisionDamage() //si choca, pierde vida
    {
        DoDamage(10);
    }

    public void DoDamage(int val) 
    {
        _currentHp -= Mathf.Abs(val);
        if (_currentHp <= 0)
        {
            _onDie?.Invoke();
            _currentHp = _maxHp;
        }

        healthBar.SetHealth(_currentHp);
    }

}
