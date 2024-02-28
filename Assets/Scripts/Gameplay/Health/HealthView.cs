using TMPro;
using UnityEngine;

public class HealthView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _healthView;
    [SerializeField] private HealthData _health;

    private void OnEnable()
    {
        _health.HealthChanged += UpdateHealthView;
    }

    private void Start()
    {
        UpdateHealthView();
    }

    private void OnDisable()
    {
        _health.HealthChanged -= UpdateHealthView;
    }

    private void UpdateHealthView()
    {
        _healthView.text = _health.CurrentHealth.ToString();
    }
}