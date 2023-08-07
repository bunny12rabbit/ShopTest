namespace Core
{
    public interface ISpend
    {
        bool CanSpend { get; }
        
        bool TrySpend();
    }
}