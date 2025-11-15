using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public sealed class NavigationPanel : MonoBehaviour
    {
        [SerializeField] private CameraSwitch _cameraSwitch;
        [Space(10f)]
        [SerializeField] private Button _transformatorButton;
        [SerializeField] private Button _reactorButton;
        [SerializeField] private Button _serviceButton;

        private void OnEnable()
        {
            _transformatorButton.onClick.AddListener(_cameraSwitch.ToTransformatorCamera);
            _reactorButton.onClick.AddListener(_cameraSwitch.ToReactorCamera);
            _serviceButton.onClick.AddListener(_cameraSwitch.ToServiceCamera);
        }

        private void OnDisable()
        {
            _transformatorButton.onClick.RemoveListener(_cameraSwitch.ToTransformatorCamera);
            _reactorButton.onClick.RemoveListener(_cameraSwitch.ToReactorCamera);
            _serviceButton.onClick.RemoveListener(_cameraSwitch.ToServiceCamera);
        }
    }
}