using Core;
using Core.Common;

namespace Client.Resources.Rating
{
    public class RatingManager : Singleton<RatingManager>
    {
        private const int INITIAL_AMOUNT = 1;
        
        public IConsumable Consumable { get; } = new Rating(INITIAL_AMOUNT);

        public IResource Resource => Consumable;
    }
}