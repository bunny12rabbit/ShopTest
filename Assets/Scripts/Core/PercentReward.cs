using System;
using UnityEngine;

namespace Core
{
    [Serializable]
    public abstract class PercentReward : IReward
    {
        [SerializeField]
        private int _amountPercent;

        protected abstract IResource Resource { get; }
            
        protected abstract IRewardable Rewardable { get; }

        public void GiveReward()
        {
            var currentAmount = Resource.CurrentAmount;
            var reward = Mathf.CeilToInt(currentAmount * 0.01f * _amountPercent);
            Rewardable.TakeReward(reward);
        }
    }
}