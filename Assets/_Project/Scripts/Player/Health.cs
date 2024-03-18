using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] public float _maxHealthPlayer = 100;
    [SerializeField] private UnityEvent _onDie = new();
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
        _currentHealth -= Mathf.Abs(damage);
        if (_currentHealth <= 0) 
        { 
            _onDie.Invoke();
            _currentHealth = _maxHealthPlayer;
        
        }
    }
}
