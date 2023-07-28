namespace YandexTestTask.Gameplay
{
    public class Wallet : IWallet
    {
        public int Money { get; private set; }
        
        public void Add(int money)
        {
            Money += money;
        }
    }
}