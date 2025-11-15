using System;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "TurbineUpgradeData", menuName = "Data/Upgrade Data/TurbineUpgradeData", order = 1)]
    public sealed class TurbineData : ScriptableObject
    {
        [Serializable]
        public sealed class TurbineUpgradeData : UpgradeData
        {
            public float MaxTemperature;
        }

        [SerializeField] private TurbineUpgradeData[] _upgradeData;

        public bool TryGetDataByLevel(int level, out TurbineUpgradeData upgradeData)
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