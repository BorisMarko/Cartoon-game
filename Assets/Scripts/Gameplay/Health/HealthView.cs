using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _healthView;
    [SerializeField] private HealthData _health;
    [SerializeField] private Slider _healthbar;

    private void Start()
    {
        _healthbar.maxValue = _health.MaxHealth;
        UpdateHealthView();
    }

    private void OnEnable()
    {
        _health.HealthChanged += UpdateHealthView;
        _health.Died += HandleDeath;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= UpdateHealthView;
        _health.Died -= HandleDeath;
    }

    private void UpdateHealthView()
    {
        _healthView.text = $"{_health.CurrentHealth}/{_health.MaxHealth}";
        _healthbar.value = _health.CurrentHealth;
    }

    private void HandleDeath()
    {
        _healthbar.gameObject.SetActive(false);
        _healthView.gameObject.SetActive(false);
    }
}
