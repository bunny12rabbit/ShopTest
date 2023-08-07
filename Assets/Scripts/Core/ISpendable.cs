namespace Core
{
    public interface ISpendable
    {
        bool CanSpend(int amount);

        bool TrySpend(int amount);
    }
}