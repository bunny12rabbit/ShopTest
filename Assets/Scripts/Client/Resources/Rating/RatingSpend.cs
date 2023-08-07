using Core;
using JetBrains.Annotations;

namespace Client.Resources.Rating
{
    [UsedImplicitly]
    public class RatingSpend : FixedSpend
    {
        protected override IConsumable Consumable => RatingManager.Instance.Consumable;
    }
}