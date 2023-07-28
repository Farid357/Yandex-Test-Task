using TMPro;
using UnityEngine;

namespace YandexTestTask.Gameplay
{
    public class WalletView : MonoBehaviour, IWalletView
    {
        [SerializeField] private TMP_Text _text;
        
        public void Visualize(int money)
        {
            _text.text = money.ToString();
        }
    }
}