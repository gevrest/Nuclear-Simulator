using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

        private int _reactorLevel = 1;
        private int _turbineLevel = 1;
        private int _transformatorLevel = 1;
    }
}