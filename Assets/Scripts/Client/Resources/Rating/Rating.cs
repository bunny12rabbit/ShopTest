using Core;
using Unity.Mathematics;

namespace Client.Resources.Rating
{
    public class Rating : Resource, IConsumable
    {
        public Rating(int initialAmount) : base(initialAmount)
        {
        }

        public override ResourceTypes ResourceType => ResourceTypes.Rating;
        
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