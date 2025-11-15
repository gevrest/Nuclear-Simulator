using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public sealed class FuelRestorator : MonoBehaviour
    {
        [SerializeField] private TransformatorController _transformatorController;
        [SerializeField] private ReactorController _reactorController;
        [SerializeField] private Button _restoreButton;

        private void OnEnable()
        {
            _restoreButton.onClick.AddListener(RestoreFuel);
        }

        private void OnDisable()
        {
            _restoreButton.onClick.RemoveListener(RestoreFuel);
        }

        private void RestoreFuel()
        {
            if (_transformatorController.TryDebitMoney(2500f))
            {
                _reactorController.RestoreFuel();
            }
        }
    }
}