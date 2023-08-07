using Core;
using JetBrains.Annotations;

namespace Client.Resources.Health
{
    [UsedImplicitly]
    public class PercentHealthSpend : PercentSpend
    {
        protected override IResource Resource => HealthManager.Instance.Resource;

        protected override ISpendable Spendable => HealthManager.Instance.Consumable;
    }
}