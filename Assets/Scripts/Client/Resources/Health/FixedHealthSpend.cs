using Core;
using JetBrains.Annotations;

namespace Client.Resources.Health
{
    [UsedImplicitly]
    public class FixedHealthSpend : FixedSpend
    {
        protected override IConsumable Consumable => HealthManager.Instance.Consumable;
    }
}