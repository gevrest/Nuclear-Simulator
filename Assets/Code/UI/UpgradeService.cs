using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Game.ReactorData;
using static Game.TransformatorData;
using static Game.TurbineData;

namespace Game
{
    public sealed class UpgradeService : MonoBehaviour
    {
        [SerializeField] private ReactorController _reactorController;
        [SerializeField] private TransformatorController _transformatorController;
        [Space(10f)]
        [SerializeField] private TMP_Text _reactorMaxTemperature;
        [SerializeField] private TMP_Text _reactorMaxPressure;
        [SerializeField] private TMP_Text _turbineMaxTemperature;
        [SerializeField] private TMP_Text _transformatorGenerationRate;
        [SerializeField] private TMP_Text _reactorUpgradeCost;
        [SerializeField] private TMP_Text _turbineUpgradeCost;
        [SerializeField] private TMP_Text _transformatorUpgradeCost;
        [Space(10f)]
        [SerializeField] private Button _reactorUpgradeButton;
        [SerializeField] private Button _turbineUpgradeButton;
        [SerializeField] private Button _transformatorUpgradeButton;
        [Space(10f)]
        [SerializeField] private TMP_Text _turbineBrokenWarning;
        [SerializeField] private Button _turbineRepairButton;
        [Space(10f)]
        [SerializeField] private int _maxReactorLevel = 3;
        [SerializeField] private int _maxTurbineLevel = 3;
        [SerializeField] private int _maxTransformatorLevel = 3;
        [Space(10f)]
        [SerializeField] private ReactorData _reactorData;
        [SerializeField] private TurbineData _turbineData;
        [SerializeField] private TransformatorData _transformatorData;

        public int ReactorLevel { get; private set; } = 1;
        public int TurbineLevel { get; private set; } = 1;
        public int TransformatorLevel { get; private set; } = 1;

        private void OnEnable()
        {
            _reactorUpgradeButton.onClick.AddListener(UpgradeReactor);
            _turbineUpgradeButton.onClick.AddListener(UpgradeTurbine);
            _transformatorUpgradeButton.onClick.AddListener(UpgradeTransformator);
            _turbineRepairButton.onClick.AddListener(RepairTurbine);
        }

        private void OnDisable()
        {
            _reactorUpgradeButton.onClick.RemoveListener(UpgradeReactor);
            _turbineUpgradeButton.onClick.RemoveListener(UpgradeTurbine);
            _transformatorUpgradeButton.onClick.RemoveListener(UpgradeTransformator);
            _turbineRepairButton.onClick.RemoveListener(RepairTurbine);
        }

        private void Awake()
        {
            if (_reactorData.TryGetDataByLevel(ReactorLevel, out ReactorUpgradeData reactorUpgradeData))
            {
                _reactorController.SetReactorData(reactorUpgradeData);
            }

            if (_turbineData.TryGetDataByLevel(TurbineLevel, out TurbineUpgradeData turbineUpgradeData))
            {
                _reactorController.SetTurbineData(turbineUpgradeData);
            }
            UpdateUpgradeInfo();
            SetElements();
        }

        private void Update()
        {
            if (_reactorController.TurbineBroken)
            {
                _turbineBrokenWarning.gameObject.SetActive(true);
                _turbineRepairButton.gameObject.SetActive(true);
            }
            else
            {
                _turbineBrokenWarning.gameObject.SetActive(false);
                _turbineRepairButton.gameObject.SetActive(false);
            }
        }

        private void UpgradeReactor()
        {
            if (ReactorLevel + 1 <= _maxReactorLevel)
            {
                if (_reactorData.TryGetDataByLevel(ReactorLevel + 1, out ReactorUpgradeData reactorUpgradeData))
                {
                    if (_transformatorController.TryDebitMoney(reactorUpgradeData.UpgradeCost))
                    {
                        ReactorLevel += 1;
                        _reactorController.SetReactorData(reactorUpgradeData);
                    }
                }
            }
            UpdateUpgradeInfo();
            SetElements();
        }

        private void UpgradeTurbine()
        {
            if (TurbineLevel + 1 <= _maxTurbineLevel)
            {
                if (_turbineData.TryGetDataByLevel(TurbineLevel + 1, out TurbineUpgradeData turbineUpgradeData))
                {
                    if (_transformatorController.TryDebitMoney(turbineUpgradeData.UpgradeCost))
                    {
                        TurbineLevel += 1;
                        _reactorController.SetTurbineData(turbineUpgradeData);
                    }
                }
            }
            UpdateUpgradeInfo();
            SetElements();
        }

        private void UpgradeTransformator()
        {
            if (TransformatorLevel + 1 <= _maxTransformatorLevel)
            {
                if (_transformatorData.TryGetDataByLevel(TransformatorLevel + 1, out TransformatorUpgradeData transformatorUpgradeData))
                {
                    if (_transformatorController.TryDebitMoney(transformatorUpgradeData.UpgradeCost))
                    {
                        TransformatorLevel += 1;
                        _transformatorController.SetTransformatorData(transformatorUpgradeData);
                    }
                }
            }
            UpdateUpgradeInfo();
            SetElements();
        }

        private void UpdateUpgradeInfo()
        {
            //Reactor info
            if (_reactorData.TryGetDataByLevel(ReactorLevel, out ReactorUpgradeData reactorUpgradeData))
            {
                _reactorMaxTemperature.text = $"Max temperature: {reactorUpgradeData.MaxTemperature}°C";
                _reactorMaxPressure.text = $"Max pressure: {reactorUpgradeData.MaxPressure}bar";
            }
            if (_reactorData.TryGetDataByLevel(ReactorLevel + 1, out ReactorUpgradeData nextLevelReactorData))
                _reactorUpgradeCost.text = $"Upgrade cost: {nextLevelReactorData.UpgradeCost}$";

            //Turbine info
            if (_turbineData.TryGetDataByLevel(TurbineLevel, out TurbineUpgradeData turbineUpgradeData))
            {
                _turbineMaxTemperature.text = $"Max temperature: {turbineUpgradeData.MaxTemperature}°C";
            }
            if (_turbineData.TryGetDataByLevel(TurbineLevel + 1, out TurbineUpgradeData nextLevelTurbineData))
                _turbineUpgradeCost.text = $"Upgrade cost: {nextLevelTurbineData.UpgradeCost}$";

            //Transformator info
            if (_transformatorData.TryGetDataByLevel(TransformatorLevel, out TransformatorUpgradeData transformatorUpgradeData))
            {
                _transformatorGenerationRate.text = $"Generation rate: x{transformatorUpgradeData.GenerationRate}";                
            }
            if (_transformatorData.TryGetDataByLevel(TransformatorLevel + 1, out TransformatorUpgradeData nextLevelTransformatorData))
                _transformatorUpgradeCost.text = $"Upgrade cost: {nextLevelTransformatorData.UpgradeCost}$";
        }

        private void SetElements()
        {
            if (ReactorLevel == _maxReactorLevel)
            {
                _reactorUpgradeButton.gameObject.SetActive(false);
                _reactorUpgradeCost.gameObject.SetActive(false);
            }

            if (TurbineLevel == _maxTurbineLevel)
            {
                _turbineUpgradeButton.gameObject.SetActive(false);
                _turbineUpgradeCost.gameObject.SetActive(false);
            }

            if (TransformatorLevel == _maxTransformatorLevel)
            {
                _transformatorUpgradeButton.gameObject.SetActive(false);
                _transformatorUpgradeCost.gameObject.SetActive(false);
            }
        }

        private void RepairTurbine()
        {
            if (_transformatorController.TryDebitMoney(2500f))
            {
                _reactorController.RepairTurbine();
            }
        }
    }
}