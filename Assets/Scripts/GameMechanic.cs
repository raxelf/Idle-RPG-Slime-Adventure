using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static AllNotation;

public class GameMechanic : MonoBehaviour
{   
    // Coin
    public static double Coin;
    public Text CoinText_Unity;
    // Shop Currency
    public Text shopCoinText;
    public Text shopRubyText;

    // RSS
    public int Ruby;
    public Text RubyText;

    public int Ichor;
    public Text IchorText;

    // Energy
    public Slider Stamina_Unity;
    public float maxStamina = 100;
    public static float currentStamina;

    // Hunger
    public Slider Hunger_Unity;
    public float maxHunger = 100;
    public static float currentHunger;

    // Fun
    public Slider Fun_Unity;
    public float maxFun = 100;
    public static float currentFun;

    void Start()
    {
        Time.timeScale = 1f;

        // Stat Max Value
        Hunger_Unity.maxValue = maxHunger;
        Stamina_Unity.maxValue = maxStamina;
        Fun_Unity.maxValue = maxFun;
    }

    void Update()
    {
        // Player Prefs
        Coin = PlayerPrefs.GetInt("Coin");
        Ichor = PlayerPrefs.GetInt("Ichor");
        Ruby = PlayerPrefs.GetInt("Ruby");

        // Set Stamina, Coin
        Stamina_Unity.value = currentStamina;
        CoinText_Unity.text = CoinNotation.CoinAfterNotation;

        // Shop Currency
        shopCoinText.text = CoinNotation.CoinAfterNotation;
        

        // RSS
        Convert(Ruby);
        RubyText.text = AllNotation.AfterNotation;
        shopRubyText.text = AllNotation.AfterNotation;
        Convert(Ichor);
        IchorText.text = AllNotation.AfterNotation;
        
        // Decreasing Hunger
        Hunger_Unity.value = currentHunger;
        currentHunger -= .1f * Time.deltaTime;

        if(currentHunger >= maxHunger){
            currentHunger = maxHunger;
        }
        if(currentHunger <= 0){
            currentHunger = 0;
        }

        // Decreasing Fun
        Fun_Unity.value = currentFun;
        currentFun -= .3f * Time.deltaTime;

        if(currentFun >= maxFun){
            currentFun = maxFun;
        }
        if(currentFun <= 0){
            currentFun = 0;
        }
    }
}