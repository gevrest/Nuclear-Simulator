using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public sealed class ReactorDisplay : MonoBehaviour
    {
        [SerializeField] private ReactorController _reactorController;
        [Header("Information")]
        [SerializeField] private TMP_Text _reactorTemperature;
        [SerializeField] private TMP_Text _reactorPressure;
        [SerializeField] private TMP_Text _turbineTemperature;
        [SerializeField] private Image _fuelReserve;
        [Header("Warnings")]
        [SerializeField] private Image _reactorTemperatureWarn;
        [SerializeField] private Image _reactorPressureWarn;
        [SerializeField] private Image _turbineTemperatureWarn;
        [SerializeField] private GameObject _lowFuelWarn;

        private void Update()
        {
            _reactorTemperature.text = $"{(int)_reactorController.ReactorTemperature}°C";
            _reactorPressure.text = $"{(int)_reactorController.ReactorPressure}bar";
            _turbineTemperature.text = $"{(int)_reactorController.TurbineTemperature}°C";
            _fuelReserve.fillAmount = _reactorController.FuelReserve;
            _lowFuelWarn.SetActive(_reactorController.LowFuel);

            _reactorTemperatureWarn.gameObject.SetActive(_reactorController.ReactorOverheated);
            _reactorPressureWarn.gameObject.SetActive(_reactorController.ReactorOverpressured);
            _turbineTemperatureWarn.gameObject.SetActive(_reactorController.TurbineOverheated);
        }
    }
}