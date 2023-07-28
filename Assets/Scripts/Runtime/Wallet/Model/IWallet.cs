namespace YandexTestTask.Gameplay
{
    public interface IWallet
    {
        int Money { get; }

        void Add(int money);
    }
}