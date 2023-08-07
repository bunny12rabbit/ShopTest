using Core;
using Core.Common;

namespace Client.Resources.Gold
{
    public class GoldManager : Singleton<GoldManager>
    {
        private const int INITIAL_AMOUNT = 1000;
        
        public IConsumable Consumable { get; } = new Gold(INITIAL_AMOUNT);

        public IResource Resource => Consumable;
    }
}