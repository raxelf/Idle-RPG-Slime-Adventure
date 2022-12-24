using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;


public class LevelUP_Script : MonoBehaviour
{
    // Exp
    public static int level;
    public static int current_EXP;
    public static int max_EXP;
    public static float temp_max_EXP;

    public Slider EXP_Slider;

    // LevelUpNotif
    public static bool Leveledup = false;

    // Stat
    public static int hp;
    public static int atk;
    public static int def;
    public static int crit;
    public static int cdmg;
    public static int spd;
    public static int stamina;
    public static int temp_int;

    // Evolution Data
    public static int[] Evolution = {
        5,10,15,20,25,
        30,35,40,45,50,
        60,70,80,90,100,
        120,140,160,180,200,
        250,300,400,500
    };
    
    public static int[] HP_UP = {
        10,25,50,75,100,
        150,300,500,1000,
        2000,5000,8000,10000,20000,
        30000,50000,80000,100000,150000,
        200000,250000,350000,500000
    };

    public static int[] Def_UP = {
        5,10,25,50,100,
        150,200,250,500,700,
        1000,1500,2500,3500,5000,
        7000,8000,10000,15000,25000,
        50000,75000,100000,200000
    };

    public static int[] Atk_UP = {
        5,20,50,75,100,
        150,200,250,500,1000,
        2500,5000,10000,25000,50000,
        70000,90000,110000,150000,200000,
        250000,300000,400000,500000
    };

    public static int[] Cdmg_UP = {
        5,50,100,150,200,
        250,300,500,800,1000,
        2000,5000,10000,25000,50000,
        75000,100000,125000,150000,200000,
        250000,400000,500000,800000
    };

    public static int Spd_UP = 3;
    public static int Crit_UP = 1;

    void Start()
    {
        level = PlayerPrefs.GetInt("Level");
        if(level <= 0){
            PlayerPrefs.SetInt("Level", 1);
        }

        current_EXP = PlayerPrefs.GetInt("Current_EXP");
        if(current_EXP <= 0){
            PlayerPrefs.SetInt("Current_EXP", 0);
        }

        max_EXP = PlayerPrefs.GetInt("Max_EXP");
        if(max_EXP <= 500){
            PlayerPrefs.SetInt("Max_EXP", 500);
        }
    }

    void Update()
    {
        // PlayerPref Set
        level = PlayerPrefs.GetInt("Level");
        current_EXP = PlayerPrefs.GetInt("Current_EXP");
        temp_max_EXP = 500 * Mathf.Pow((PlayerPrefs.GetInt("Level")), 0.8f);
        max_EXP = (int)temp_max_EXP;
        PlayerPrefs.SetInt("Max_EXP", max_EXP);

        // EXP Bar
        EXP_Slider.maxValue = max_EXP;
        EXP_Slider.value = current_EXP;
    }

    public static void isLevelUP(){
        // Level Up Script
        if(Evolution.Contains(level)){
            if(PlayerPrefs.GetInt("Current_EXP") >= PlayerPrefs.GetInt("Max_EXP")){
                PlayerPrefs.SetInt("Current_EXP",PlayerPrefs.GetInt("Max_EXP"));
            }
        }
        else
        {
            if(PlayerPrefs.GetInt("Current_EXP") >= PlayerPrefs.GetInt("Max_EXP")){
                level += 1;
                PlayerPrefs.SetInt("Level", level);

                current_EXP = current_EXP - max_EXP;
                PlayerPrefs.SetInt("Current_EXP", current_EXP);

                temp_max_EXP = max_EXP * 1.25f;
                max_EXP = (int)temp_max_EXP;
                PlayerPrefs.SetInt("Max_EXP", max_EXP);

                LevelUP();
            }
        }
    }
    
    public static void LevelUP(){
        Leveledup = true;
        hp = PlayerPrefs.GetInt("HP_Stat");
        hp += HP_UP[PlayerPrefs.GetInt("EvoLevel")];
        PlayerPrefs.SetInt("HP_Stat", hp);

        atk = PlayerPrefs.GetInt("Atk_Stat");
        atk += Atk_UP[PlayerPrefs.GetInt("EvoLevel")];
        PlayerPrefs.SetInt("Atk_Stat", atk);

        def = PlayerPrefs.GetInt("Def_Stat");
        def += Def_UP[PlayerPrefs.GetInt("EvoLevel")];
        PlayerPrefs.SetInt("Def_Stat", def);

        cdmg = PlayerPrefs.GetInt("Cdmg_Stat");
        cdmg += Cdmg_UP[PlayerPrefs.GetInt("EvoLevel")];
        PlayerPrefs.SetInt("Cdmg_Stat", cdmg);

        crit = PlayerPrefs.GetInt("Crit_Stat");
        crit += Crit_UP;
        PlayerPrefs.SetInt("Crit_Stat", crit);

        spd = PlayerPrefs.GetInt("Spd_Stat");
        spd += Spd_UP;
        PlayerPrefs.SetInt("Spd_Stat", spd);
    }
}
