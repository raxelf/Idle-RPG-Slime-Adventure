using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static AllNotation;

public class HP_Filler : MonoBehaviour
{
    public Text HP_Text;
    public Slider HP_Bar;
    public Image HP_Color;

    public Slider Enemy_Bar;
    public Text Enemy_HP_Text;

    public static int currentHP;
    public static int maxHP;
    public float currentHP2;
    public float maxHP2;
    public string currentHP_string;
    public string maxHP_string;

    public static int Enemy_currentHP;
    public static int Enemy_maxHP;
    public float Enemy_currentHP2;
    public float Enemy_maxHP2;
    public string Enemy_currentHP_string;
    public string Enemy_maxHP_string;

    public void Start()
    {
        // Set Max HP
        Enemy_maxHP = EnemyProfile.HP;
        maxHP = PlayerProfile.HP_nerfed;

        // Set Value max hp and slider
        currentHP = maxHP;
        HP_Bar.value = maxHP;

        Enemy_currentHP = Enemy_maxHP;
        Enemy_Bar.value = Enemy_maxHP;
    }

    public void Update()
    {
        // HP cant decrease below 0
        if(currentHP <= 0)
            currentHP = 0;

        if(Enemy_currentHP <= 0)
            Enemy_currentHP = 0;
            
        // Set Variable (Save maxHP and currentHP as float)
        maxHP2 = maxHP;
        currentHP2 = currentHP;

        Enemy_currentHP2 = Enemy_currentHP;
        Enemy_maxHP2 = Enemy_maxHP;

        // Set MAX HP and Bar
        HP_Bar.maxValue = maxHP;
        Enemy_Bar.maxValue = Enemy_maxHP;

        HP_Bar.value = currentHP;
        Enemy_Bar.value = Enemy_currentHP;

        //Max HP FIXED
        if(Enemy_currentHP >= Enemy_maxHP){
            Enemy_currentHP = Enemy_maxHP;
        }

        if(currentHP >= maxHP){
            currentHP = maxHP;
        }

        // Update value hp and slider
        Convert(currentHP2);
        currentHP_string = AllNotation.AfterNotation;

        Convert(maxHP2);
        maxHP_string = AllNotation.AfterNotation;

        HP_Text.text = currentHP_string + "/" + maxHP_string;

        HP_Color.color = Color.Lerp(Color.red, Color.green, HP_Bar.value / maxHP);

        Convert(Enemy_currentHP2);
        Enemy_currentHP_string = AllNotation.AfterNotation;

        Convert(Enemy_maxHP2);
        Enemy_maxHP_string = AllNotation.AfterNotation;

        Enemy_HP_Text.text = Enemy_currentHP_string + "/" + Enemy_maxHP_string;

    }
}
