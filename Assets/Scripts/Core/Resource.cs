using UniRx;

namespace Core
{
    public abstract class Resource : IResource
    {
        private readonly int _initialAmount;

        protected Resource(int initialAmount)
        {
            _initialAmount = initialAmount;
            currentAmount.Value = initialAmount;
        }

        protected ReactiveProperty<int> currentAmount = new();

        public string Name => ResourceType.ToString();

        public abstract ResourceTypes ResourceType { get; }

        int IResource.InitialAmount => _initialAmount;
        int IResource.CurrentAmount => currentAmount.Value;
        
        IReadOnlyReactiveProperty<int> IResource.CurrentAmountReactive => currentAmount;
    }
}