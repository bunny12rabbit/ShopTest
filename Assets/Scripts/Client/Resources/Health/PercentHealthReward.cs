using Core;
using JetBrains.Annotations;

namespace Client.Resources.Health
{
    [UsedImplicitly]
    public class PercentHealthReward : PercentReward
    {
        protected override IResource Resource => HealthManager.Instance.Resource;
        protected override IRewardable Rewardable => HealthManager.Instance.Consumable;
    }
}