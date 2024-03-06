using UnityEngine;

public class Enemy : MonoBehaviour
{
    public event System.Action<int> DamageReceived;

    [SerializeField] private HealthData _health;

    private void OnEnable()
    {
        _health.Died += HandleDeath;
    }

    private void OnDestroy()
    {
        _health.Died -= HandleDeath;
    }

    private void HandleDeath()
    {
        Destroy(gameObject); //Заменить на возвращение в пул.
    }

    public void TakeDamage(int damage)
    {
        _health.ReduceHealth(damage);
        DamageReceived?.Invoke(damage);
    }
}
