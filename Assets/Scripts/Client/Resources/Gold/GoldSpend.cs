using Core;
using JetBrains.Annotations;

namespace Client.Resources.Gold
{
    [UsedImplicitly]
    public class GoldSpend : FixedSpend
    {
        protected override IConsumable Consumable => GoldManager.Instance.Consumable;
    }
}