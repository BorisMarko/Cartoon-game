using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Health stats")]
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private int _maxHealth = 100;

    private int _currentHealth;

    public event Action<float> HealthChanged;

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

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    //Отладка
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ChangeHealth(-10);
        }
    }

    private void ChangeHealth(int value)
    {
        _currentHealth += value;

        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            _healthBar.gameObject.SetActive(false);
            Death(); //Дописать метод для смерти.
        }
        else
        {
            if (_healthBar.gameObject == false) 
                _healthBar.gameObject.SetActive(true);

            float _currentHealthAsPercantage = (float)_currentHealth / _maxHealth;
            HealthChanged?.Invoke(_currentHealthAsPercantage);
        }
    }

    private void Death()
    {
        HealthChanged?.Invoke(0);
    }
}
