using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WalletUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textWallet;
    private void OnEnable()
    {
        Wallet.WalletChange += UIView;
    }

    private void OnDisable()
    {
        Wallet.WalletChange -= UIView;
    }

    private void UIView(int _valuta)
    {
        textWallet.text = _valuta + " Ð";
    }
}
