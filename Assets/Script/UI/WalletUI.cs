using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WalletUI : MonoBehaviour
{
    public TextMeshProUGUI walletUI;
    int currentWallet;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentWallet = GameManager.Instance.wallet;
        UpWallet();
        
    }

    void FixedUpdate()
    {
        currentWallet = GameManager.Instance.wallet;
        UpWallet();
    }

    void UpWallet() {
        walletUI.text = currentWallet.ToString();        
    }
}
