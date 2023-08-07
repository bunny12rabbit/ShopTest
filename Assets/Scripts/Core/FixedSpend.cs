using System;
using UnityEngine;

namespace Core
{
    [Serializable]
    public abstract class FixedSpend : ISpend
    {
        [SerializeField]
        private int _amount;

        protected abstract IConsumable Consumable { get; }

        public bool CanSpend => Consumable.CanSpend(_amount);

        public bool TrySpend() => Consumable.TrySpend(_amount);
    }
}