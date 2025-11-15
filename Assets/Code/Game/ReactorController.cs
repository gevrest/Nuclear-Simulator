using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using static Game.ReactorData;
using static Game.TurbineData;

namespace Game
{
    public sealed class ReactorController : MonoBehaviour
    {
        [SerializeField] private Slider _reactorSlider;
        [SerializeField] private Slider _pumpSlider;
        [SerializeField] private Transform _controlRods;
        [SerializeField] private Transform _pumpFan;
        [SerializeField] private LoseMenu _loseScreen;
        [Header("Minimum Values")]
        [SerializeField] private float _minReactorTemperature = 20f;
        [SerializeField] private float _minReactorPressure = 1f;
        [SerializeField] private float _minTurbineTemperature = 20f;

        private float _warnReactorTemperature;
        private float _warnReactorPressure;
        private float _warnTurbineTemperature;

        private float _maxReactorTemperature;
        private float _maxReactorPressure;
        private float _maxTurbineTemperature;

        private Vector3 _defaultRodsPosition;

        public float ReactorTemperature { get; private set; }
        public float ReactorPressure { get; private set; }
        public float TurbineTemperature { get; private set; }
        public float FuelReserve { get; private set; }

        public bool ReactorOverheated { get; private set; }
        public bool ReactorOverpressured { get; private set; }
        public bool TurbineOverheated { get; private set; }
        public bool TurbineBroken { get; private set; }
        public bool LowFuel { get; private set; }

        private void Awake()
        {
            ReactorTemperature = _minReactorTemperature;
            ReactorPressure = _minReactorPressure;
            TurbineTemperature = _minTurbineTemperature;
            FuelReserve = 1f;
        }

        private void Start()
        {
            _defaultRodsPosition = _controlRods.position;
            StartCoroutine(ReactorOperation());
        }

        private void Update()
        {
            ReactorOverheated = ReactorTemperature >= _warnReactorTemperature ? true : false;
            ReactorOverpressured = ReactorPressure >= _warnReactorPressure ? true : false;
            TurbineOverheated = TurbineTemperature >= _warnTurbineTemperature ? true : false;
            LowFuel = FuelReserve <= 0.3f ? true : false;

            if (TurbineBroken)
                _pumpSlider.value = 0f;
            else
                TurbineBroken = TurbineTemperature >= _maxTurbineTemperature ? true : false;

            if (ReactorTemperature >= _maxReactorTemperature || ReactorPressure >= _maxReactorPressure)
            {
                _loseScreen.LoseGame();
            }
        }

        private void FixedUpdate()
        {
            _controlRods.position = _defaultRodsPosition + new Vector3(0, _reactorSlider.value * 1.5f, 0);
            _pumpFan.Rotate(new Vector3(0, 0, _pumpSlider.value) * 500 * Time.fixedDeltaTime);
        }

        private IEnumerator ReactorOperation()
        {
            while (true)
            {
                ReactorTemperature += ((4f + Random.Range(0.015f, 0.02f)) * _reactorSlider.value * FuelReserve) - (0.5f * _pumpSlider.value) - 0.2f;
                ReactorPressure += ((0.26f - Random.Range(0.015f, 0.02f)) * _reactorSlider.value * FuelReserve) - (0.0325f * _pumpSlider.value) - 0.01f;
                if (_pumpSlider.value == 1f)
                {
                    if (TurbineTemperature < (18f + (ReactorTemperature / 8f)))
                    {
                        TurbineTemperature += 0.35f;
                    }
                    else
                    {
                        TurbineTemperature = 18f + (ReactorTemperature / 8f);
                    }
                }
                else
                {
                    TurbineTemperature -= 0.25f;
                }
                FuelReserve -= 0.0005f * _reactorSlider.value;

                ReactorTemperature = Mathf.Max(ReactorTemperature, _minReactorTemperature);
                ReactorPressure = Mathf.Max(ReactorPressure, _minReactorPressure);
                TurbineTemperature = Mathf.Max(TurbineTemperature, _minTurbineTemperature);
                FuelReserve = Mathf.Max(FuelReserve, 0f);

                yield return new WaitForSeconds(0.1f);
            }
        }

        public void RestoreFuel()
        {
            FuelReserve = 1f;
        }

        public void RepairTurbine()
        {
            TurbineBroken = false;
            TurbineTemperature = _minTurbineTemperature;
        }

        public void SetReactorData(ReactorUpgradeData reactorUpgradeData)
        {
            _maxReactorTemperature = reactorUpgradeData.MaxTemperature;
            _maxReactorPressure = reactorUpgradeData.MaxPressure;

            _warnReactorTemperature = _maxReactorTemperature - 200f;
            _warnReactorPressure = _maxReactorPressure - 40f;
        }

        public void SetTurbineData(TurbineUpgradeData turbineUpgradeData)
        {
            _maxTurbineTemperature = turbineUpgradeData.MaxTemperature;

            _warnTurbineTemperature = _maxTurbineTemperature - 50f;
        }
    }
}   