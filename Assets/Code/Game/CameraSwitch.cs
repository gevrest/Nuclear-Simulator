using UnityEngine;

namespace Game
{
    public sealed class CameraSwitch : MonoBehaviour
    {
        [SerializeField] private Camera _reactorCamera;
        [SerializeField] private Camera _transformatorCamera;
        [SerializeField] private Camera _serviceCamera;

        private void Start()
        {
            _reactorCamera = Camera.main;
        }

        public void ToReactorCamera()
        {
            DisableAllCameras();
            _reactorCamera.gameObject.SetActive(true);
        }

        public void ToTransformatorCamera()
        {
            DisableAllCameras();
            _transformatorCamera.gameObject.SetActive(true);
        }

        public void ToServiceCamera()
        {
            DisableAllCameras();
            _serviceCamera.gameObject.SetActive(true);
        }

        private void DisableAllCameras()
        {
            _reactorCamera.gameObject.SetActive(false);
            _transformatorCamera.gameObject.SetActive(false);
            _serviceCamera.gameObject.SetActive(false);
        }
    }
}