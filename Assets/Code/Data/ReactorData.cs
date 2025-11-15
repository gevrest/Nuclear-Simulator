using System;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "ReactorUpgradeData", menuName = "Data/Upgrade Data/ReactorUpgradeData", order = 0)]
    public sealed class ReactorData : ScriptableObject
    {
        [Serializable]
        public sealed class ReactorUpgradeData : UpgradeData
        {
            public float MaxTemperature;
            public float MaxPressure;
        }

        [SerializeField] private ReactorUpgradeData[] _upgradeData;

        public bool TryGetDataByLevel(int level, out ReactorUpgradeData upgradeData)
        {
            for (int i = 0; i < _upgradeData.Length; i++)
            {
                if (_upgradeData[i].Level == level)
                {
                    upgradeData = _upgradeData[i];
                    return true;
                }
            }
            upgradeData = _upgradeData[0];
            return false;
        }
    }
}