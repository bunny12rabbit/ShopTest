using Core;
using JetBrains.Annotations;

namespace Client.Resources.Gold
{
    [UsedImplicitly]
    public class GoldReward : FixedReward
    {
        protected override IRewardable Rewardable => GoldManager.Instance.Consumable;
    }
}