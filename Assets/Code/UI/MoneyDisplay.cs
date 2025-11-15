using TMPro;
using UnityEngine;

namespace Game
{
    public sealed class MoneyDisplay : MonoBehaviour
    {
        [SerializeField] private TransformatorController _transformatorController;
        [SerializeField] private TMP_Text _moneyValue;

        private void Update()
        {
            _moneyValue.text = $"{(int)_transformatorController.Money}";
        }
    }
}