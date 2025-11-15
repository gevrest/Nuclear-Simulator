using System.Collections;
using TMPro;
using UnityEngine;
using static Game.TransformatorData;

namespace Game
{
    public sealed class TransformatorController : MonoBehaviour
    {
        [SerializeField] ReactorController _reactorController;
        [SerializeField] TMP_Text _powerValue;

        private float _generationRate = 1f;

        public float Power { get; private set; }
        public float Money { get; private set; }

        private void Start()
        {
            StartCoroutine(TransformatorProcess());
        }

        private void Update()
        {
            _powerValue.text = $"{(int)Power}MW";
        }

        private IEnumerator TransformatorProcess()
        {
            while (true)
            {
                yield return new WaitForSeconds(0.05f);
                Power = _reactorController.TurbineTemperature * 5 - 100f;
                Money += Power / 500 * _generationRate;
            }
        }

        public bool TryDebitMoney(float money)
        {
            if (money <= Money)
            {
                Money -= money;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SetTransformatorData(TransformatorUpgradeData transformatorUpgradeData)
        {
            _generationRate = transformatorUpgradeData.GenerationRate;
        }
    }
}