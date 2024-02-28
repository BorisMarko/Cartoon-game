using System;
using UnityEngine;

public class HealthData : MonoBehaviour
{
    public event Action HealthChanged;
    public event Action Died;

    [SerializeField] private int _currentHealth;

    public int CurrentHealth
    {
        get { return _currentHealth; }
        private set
        {
            _currentHealth = value;
        }
    }

    public void AddHealth(int amount)
    {
        if (amount <= 0)
            return;

        CurrentHealth += amount;
        HealthChanged?.Invoke();
    }
}
