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

    public int CurrentHP => _currentHp;

    public HealthBarScript healthBar;

    private void Start()
    {
        _currentHp = PlayerPrefs.GetInt("_currentHp", _maxHp);
        ChangeHealth(CurrentHP);
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

    public void RestoreHealth()
    {
        
        if (_currentHp >= 100)
        {
            _currentHp = 100;
        } else
        {
            _currentHp += Mathf.Abs(5);
        }

        healthBar.SetHealth(_currentHp);
    }

    public void ChangeHealth(int val)
    {
       
        _currentHp = val;
        Debug.Log(val);
        healthBar.SetHealth(_currentHp);
    }

}
