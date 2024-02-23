using Cinemachine;
using StarterAssets;
using UnityEngine;
using UnityEngine.UI;

public class ThirdPersonShooterController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _aimVirtualCamera;
    [SerializeField] private Image _image;
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

    private void Update()
    {
        if (_starterAssetsInputs.aim)
        {
            _aimVirtualCamera.gameObject.SetActive(true);
            _thirdPersonController.SetSensitivity(_aimlSensitivity);
            _image.gameObject.SetActive(true);
        }
        else 
        {
            _thirdPersonController.SetSensitivity(_normalSensitivity);
            _aimVirtualCamera.gameObject.SetActive(false);
            _image.gameObject.SetActive(false);
        }
    }
}
