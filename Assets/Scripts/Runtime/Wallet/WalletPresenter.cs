using System;

namespace YandexTestTask.Gameplay
{
    public class WalletPresenter : IWallet
    {
        private readonly IWallet _wallet;
        private readonly IWalletView _view;

        public WalletPresenter(IWalletView view)
        {
            _wallet = new Wallet();
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        public int Money => _wallet.Money;

        public void Add(int money)
        {
            _wallet.Add(money);
            _view.Visualize(Money);
        }
    }
}