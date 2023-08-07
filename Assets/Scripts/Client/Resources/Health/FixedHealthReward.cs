using Core;
using JetBrains.Annotations;

namespace Client.Resources.Health
{
    [UsedImplicitly]
    public class FixedHealthReward : FixedReward
    {
        protected override IRewardable Rewardable => HealthManager.Instance.Consumable;
    }
}