using Core;
using Core.Common;

namespace Client.Resources.Health
{
    public class HealthManager : Singleton<HealthManager>
    {
        private const int INITIAL_AMOUNT = 100;
        
        public IConsumable Consumable { get; } = new Health(INITIAL_AMOUNT);

        public IResource Resource => Consumable;
    }
}