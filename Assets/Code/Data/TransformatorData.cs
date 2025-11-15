using System;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "TransformatorUpgradeData", menuName = "Data/Upgrade Data/TransformatorUpgradeData", order = 2)]
    public sealed class TransformatorData : ScriptableObject
    {
        [Serializable]
        public sealed class TransformatorUpgradeData : UpgradeData
        {
            public float GenerationRate;
        }

        [SerializeField] private TransformatorUpgradeData[] _upgradeData;

        public bool TryGetDataByLevel(int level, out TransformatorUpgradeData upgradeData)
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