using System;
using UnityEngine;

public class HealthData : MonoBehaviour
{
    public event Action HealthChanged;
    public event Action Died;

    [SerializeField, Min(50)] private int _maxHealth;

    private int _currentHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public int CurrentHealth
    {
        get { return _currentHealth; }
        private set { _currentHealth = Mathf.Clamp(value, 0, _maxHealth); }
    }

    public int MaxHealth
    {
        get { return _maxHealth; }
        private set { _maxHealth = value; }
    }

    public void AddHealth(int amount)
    {
        if (amount <= 0)
            return;

        CurrentHealth += amount;

        HealthChanged?.Invoke();
    }

    public void ReduceHealth(int amount)
    {
        if (amount <= 0)
            return;

        CurrentHealth -= amount;
        HealthChanged?.Invoke();

        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            Died?.Invoke();
        }
    }
}