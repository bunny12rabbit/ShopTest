using UniRx;

namespace Core
{
    public interface IResource
    {
        string Name { get; }
        
        ResourceTypes ResourceType { get; }
        
        int InitialAmount { get; }
        int CurrentAmount { get; }
        
        IReadOnlyReactiveProperty<int> CurrentAmountReactive { get; }
    }
}