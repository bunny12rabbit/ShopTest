using System;
using UnityEngine;

namespace Core
{
    [Serializable]
    public abstract class FixedReward : IReward
    {
        [SerializeField]
        private int _amount;

        protected abstract IRewardable Rewardable { get; }

        public void GiveReward() => Rewardable.TakeReward(_amount);
    }
}