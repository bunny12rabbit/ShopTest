using System;
using UnityEngine;

namespace Core
{
    [Serializable]
    public abstract class PercentSpend : ISpend
    {
        [SerializeField]
        private int _amountPercent;

        protected abstract IResource Resource { get; }
        
        protected abstract ISpendable Spendable { get; }

        public bool CanSpend => Spendable.CanSpend(GetSpendAmount());

        public bool TrySpend()
        {
            var spendAmount = GetSpendAmount();
            return Spendable.TrySpend(spendAmount);
        }

        private int GetSpendAmount()
        {
            var currentAmount = Resource.CurrentAmount;
            var spendAmount = Mathf.CeilToInt(currentAmount * 0.01f * _amountPercent);
            return spendAmount;
        }
    }
}