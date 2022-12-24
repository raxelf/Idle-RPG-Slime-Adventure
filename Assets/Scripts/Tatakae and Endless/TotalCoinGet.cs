using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalCoinGet : MonoBehaviour
{
    private float CoinConventor;
    public static string TotalCoinAfterNotation;

    // Start is called before the first frame update
    void Update()
    {
        CoinsConverter();

        if(TawuranSimulator.TotalCoin >= 1000)
        {
            TotalCoinAfterNotation = CoinConventor.ToString("F2") + "K";
        }
        if(TawuranSimulator.TotalCoin >= 1000000)
        {
            TotalCoinAfterNotation = CoinConventor.ToString("F2") + "M";
        }
        if (TawuranSimulator.TotalCoin >= 1000000000)
        {
            TotalCoinAfterNotation = CoinConventor.ToString("F2") + "B";
        }
        if (TawuranSimulator.TotalCoin >= 1000000000000)
        {
            TotalCoinAfterNotation = CoinConventor.ToString("F2") + "T";
        }
        if (TawuranSimulator.TotalCoin < 1000)
        {
            TotalCoinAfterNotation = "" + TawuranSimulator.TotalCoin;
        }
    }

    public void CoinsConverter()
    {
        if (TawuranSimulator.TotalCoin >= 1000)
        {
            CoinConventor = TawuranSimulator.TotalCoin / 1000;
        }
        if(TawuranSimulator.TotalCoin >= 1000000)
        {
            CoinConventor = TawuranSimulator.TotalCoin / 1000000;
        }
        if(TawuranSimulator.TotalCoin >= 1000000000)
        {
            CoinConventor = TawuranSimulator.TotalCoin / 1000000000;
        }
        if(TawuranSimulator.TotalCoin >= 1000000000000)
        {
            CoinConventor = TawuranSimulator.TotalCoin / 1000000000000;
        }
    }
}
