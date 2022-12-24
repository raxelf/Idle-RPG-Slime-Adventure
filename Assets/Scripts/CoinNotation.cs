using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinNotation : MonoBehaviour
{
    private double CoinConventor;
    public static string CoinAfterNotation;

    void Update()
    {
        CoinsConverter();

        if(GameMechanic.Coin >= 1000)
        {
            CoinAfterNotation = CoinConventor.ToString("F2") + "K";
        }
        if(GameMechanic.Coin >= 1000000)
        {
            CoinAfterNotation = CoinConventor.ToString("F2") + "M";
        }
        if (GameMechanic.Coin >= 1000000000)
        {
            CoinAfterNotation = CoinConventor.ToString("F2") + "B";
        }
        if (GameMechanic.Coin >= 1000000000000)
        {
            CoinAfterNotation = CoinConventor.ToString("F2") + "T";
        }
        if (GameMechanic.Coin < 1000)
        {
            CoinAfterNotation = "" + GameMechanic.Coin;
        }
    }

    public void CoinsConverter()
    {
        if (GameMechanic.Coin >= 1000)
        {
            CoinConventor = GameMechanic.Coin / 1000;
        }
        if(GameMechanic.Coin >= 1000000)
        {
            CoinConventor = GameMechanic.Coin / 1000000;
        }
        if(GameMechanic.Coin >= 1000000000)
        {
            CoinConventor = GameMechanic.Coin / 1000000000;
        }
        if(GameMechanic.Coin >= 1000000000000)
        {
            CoinConventor = GameMechanic.Coin / 1000000000000;
        }
    }
}