using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OLDHealth : MonoBehaviour
{
    [SerializeField] private LayerMask _enemies;
    [SerializeField] public float _maxHealthPlayer = 100;
    private float _currentHealth = default;

    [SerializeField] private UnityEvent<float> _onHealthChanged = new();
    [SerializeField] private UnityEvent _onDeath = new();



    // Start is called before the first frame update
    void Start()
    {
        _currentHealth = _maxHealthPlayer;
    }

    public void RecieveDammage(int damage)
    {
        _currentHealth -= damage;
        if (_currentHealth < 0)
        {
            _currentHealth = 0;
        }
        _onHealthChanged?.Invoke((float)_currentHealth / _maxHealthPlayer);
        if (_currentHealth == 0)
            _onDeath?.Invoke();

    }

}
