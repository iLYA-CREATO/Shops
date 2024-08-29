using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    public static event Action<int> WalletChange;
    public static event Action WalletNotEnough;

    [SerializeField] private int valuta;

    public int _valuta;
    private void Start()
    {
        WalletChange?.Invoke(valuta);
    }
    public int Valuta
    {
        get { return valuta; } // Только для чтения
        private set { _valuta = value; } 
    }

    public bool MinusValuta(int _valuta)
    {
        if (valuta < _valuta)
        {
            Debug.Log("Недостаточно средств: ");
            WalletNotEnough?.Invoke(); // Нема
            return false;
        }
        else if (valuta >= _valuta)
        {
            valuta -= _valuta;
            WalletChange?.Invoke(valuta);
            return true;
        }

        return false;
    }
}
