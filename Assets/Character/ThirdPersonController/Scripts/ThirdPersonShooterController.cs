using Cinemachine;
using StarterAssets;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ThirdPersonShooterController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _aimVirtualCamera;
    [SerializeField] private Health _health;
    [SerializeField] private TextMeshProUGUI _healthText;
    [SerializeField] private Image _crossair;
    [Header("Sensitivity")]
    [SerializeField, Min(0)] private float _normalSensitivity;
    [SerializeField, Min(0)] private float _aimlSensitivity;

    private ThirdPersonController _thirdPersonController;
    private StarterAssetsInputs _starterAssetsInputs;

    private void Awake()
    {
        _thirdPersonController = GetComponent<ThirdPersonController>();
        _starterAssetsInputs = GetComponent<StarterAssetsInputs>();
    }

    private void OnEnable()
    {
        _health.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= OnHealthChanged;
    }

    private void Start()
    {
        _healthText.text = $"{_health.CurrentHealth}/{_health.MaxHealth}"; /* —делал это тут, а не в классе Health потому, что мне не нужно чтобы у врага текстом отображалось кол-во хп.
                                                                           ЌанесЄнный урон можно будет сделать через партиклы.
                                                                           ѕока сойдет, но в будующем нужно будет изменить, т.к.
                                                                           данное решение не очень */
    }

    private void Update()
    {
        if (_starterAssetsInputs.aim)
        {
            _aimVirtualCamera.gameObject.SetActive(true);
            _thirdPersonController.SetSensitivity(_aimlSensitivity);
            _crossair.gameObject.SetActive(true);
        }
        else
        {
            _thirdPersonController.SetSensitivity(_normalSensitivity);
            _aimVirtualCamera.gameObject.SetActive(false);
            _crossair.gameObject.SetActive(false);
        }

    }
    private void OnHealthChanged(float valueAsPercantage)
    {
        _healthText.text = $"{_health.CurrentHealth}/{_health.MaxHealth}";
    }
}
