using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static AllNotation;

public class WorldBoss_HP : MonoBehaviour
{
    // Player Bars
    public Text HP_Text;
    public Slider HP_Bar;
    public Image HP_Color;

    public static int currentHP;
    public static int maxHP;
    public float currentHP2;
    public float maxHP2;
    public string currentHP_string;
    public string maxHP_string;

    public void Start()
    {
        // Set Max HP
        maxHP = PlayerProfile.HP_nerfed;

        // Set Value max hp and slider
        currentHP = maxHP;
        HP_Bar.value = maxHP;
    }

    public void Update()
    {
        // Set Variable (Save maxHP and currentHP as float)
        maxHP2 = maxHP;
        currentHP2 = currentHP;

        // Set MAX HP and Bar
        HP_Bar.maxValue = maxHP;
        HP_Bar.value = currentHP;

        //Max HP FIXED
        if(currentHP >= maxHP){
            currentHP = maxHP;
        }

        // HP cant decrease below 0
        if(currentHP <= 0)
            currentHP = 0;

        // Update value hp and slider
        Convert(currentHP2);
        currentHP_string = AllNotation.AfterNotation;

        Convert(maxHP2);
        maxHP_string = AllNotation.AfterNotation;

        HP_Text.text = currentHP_string + "/" + maxHP_string;

        HP_Color.color = Color.Lerp(Color.red, Color.green, HP_Bar.value / maxHP);
    }
}
