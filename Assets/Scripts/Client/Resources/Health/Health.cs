using Core;
using Unity.Mathematics;

namespace Client.Resources.Health
{
    public class Health : Resource, IConsumable
    {
        public Health(int initialAmount) : base(initialAmount)
        {
        }

        public override ResourceTypes ResourceType => ResourceTypes.Health;

        bool ISpendable.CanSpend(int amount) => currentAmount.Value >= math.max(1, amount);

        bool ISpendable.TrySpend(int amount)
        {
            if (currentAmount.Value < amount)
                return false;

            currentAmount.Value -= amount;
            return true;
        }

        void IRewardable.TakeReward(int amount) => currentAmount.Value += amount;
    }
}