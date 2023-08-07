using Core;
using JetBrains.Annotations;

namespace Client.Resources.Rating
{
    [UsedImplicitly]
    public class RatingReward : FixedReward
    {
        protected override IRewardable Rewardable => RatingManager.Instance.Consumable;
    }
}