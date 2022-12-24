using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static AllNotation;
using System.Linq;
using System;

public static class Extensions
{
    public static bool find<T>(this T[] array, T target) {
        return array.Contains(target);
    }
}

public class PlayerProfile : MonoBehaviour
{
    public static Sprite tatakaeCharacter;
    public Image character;
    public Image playerPicture;
    public Image playerPictureStat;
    public Image playerPictureStatReflection;
    public Image playerPictureCostume;
    public Image playerPictureCostumeReflection;
    public Image playerPictureEvolve;

    // Skin and Accessory Id
    public static int SkinID;
    public static int AccID;

    // Skin
    public Image skinBlue;
    public Image skinGreen;
    public Image skinPink;
    public Image skinYellow;
    public Image skinBlack;
    public Image skinSilver;
    public Image skinGold;
    public Image skinNoSignal;
    
    public Text Text_HP;
    public Text Text_Atk;
    public Text Text_Def;
    public Text Text_Crit;
    public Text Text_Cdmg;
    public Text Text_Spd;

    public static int HP;
    public static int Atk;
    public static int Def;
    public static int Crit;
    public static int Cdmg;
    public static int Spd;
    public static int Stamina = 3;

    // Battle Power
    public static int BattlePower;
    public Text Text_BattlePower;

    public static int CurrentFloor;
    public static int EndlessFloor;

    // Exp
    public static int level;
    public static int current_EXP;
    public static int max_EXP;
    public string tempEXP;
    public float temp_max_EXP;

    // TEMPORARY VARIABLE
    public int temp;

    // Evolution
    public Button Evolution_Button;
    public Button Evolution_Button_Menu;

    public GameObject CanEvoNotifHome;
    public GameObject CanEvoNotif;
    public GameObject EvolutionSuccess;
    public GameObject SuccessWindow;

    public Text Evolution_Text_Level1;
    public Text Evolution_Text_Level2;
    public Text Evolution_Coin;
    public Text Evolution_Ichor;

    // Stat for Evolution
    public static int hp;
    public static int atk;
    public static int def;
    public static int crit;
    public static int cdmg;
    public static int spd;

    public static int new_hp;
    public static int new_atk;
    public static int new_def;
    public static int new_crit;
    public static int new_cdmg;
    public static int new_spd;

    public Text Text_hp;
    public Text Text_atk;
    public Text Text_def;
    public Text Text_crit;
    public Text Text_cdmg;
    public Text Text_spd;

    public Text Text_new_hp;
    public Text Text_new_atk;
    public Text Text_new_def;
    public Text Text_new_crit;
    public Text Text_new_cdmg;
    public Text Text_new_spd;

    // Nerfed Stat
    public static int HP_nerfed;
    public static int Atk_nerfed;
    public static int Def_nerfed;
    public static int Crit_nerfed;
    public static int Cdmg_nerfed;
    public static int Spd_nerfed;
    
    // Evolution Material
    public int ichor;
    public int coin;
    public int EvoLevel;
    public GameObject Ichor_Box;

    // Evolution data
    public static int[] Evolution = {
        5,10,15,20,25,
        30,35,40,45,50,
        60,70,80,90,100,
        120,140,160,180,200,
        250,300,400,500
    };

    public static int[] coin_price = {
        1000, 10000, 50000, 100000, 250000,
        50000,75000,100000,150000,250000,
        500000,750000,1000000,1500000,2000000,
        3000000,5000000,7500000,10000000,15000000,
        20000000,30000000,40000000,50000000
    };
    public static int[] ichor_price = {
        0, 0, 0, 0, 100,
        200,500,1000,1500,2500,
        5000,10000,25000,50000,100000,
        125000,150000,200000,250000,400000,
        700000,1000000,2500000,5000000,
        8000000,10000000,15000000,20000000
    };

    // Badge
    public int Badge;
    public Image BadgeImage;
    public Sprite[] BadgeSprite;

    // Etc
    public Text Text_level;
    public Text EXP;
    public Slider EXP_Slider;

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
        
        EvoLevel = PlayerPrefs.GetInt("EvoLevel");
        if(EvoLevel <= 0){
            PlayerPrefs.SetInt("EvoLevel", 0);
        }

        Badge = PlayerPrefs.GetInt("Badge");
        if(Badge <= 0){
            PlayerPrefs.SetInt("Badge", 0);
        }

        HP = PlayerPrefs.GetInt("HP_Stat");
        if(HP <= 200){
            PlayerPrefs.SetInt("HP_Stat", 200);
        }

        Atk = PlayerPrefs.GetInt("Atk_Stat");
        if(Atk <= 20){
            PlayerPrefs.SetInt("Atk_Stat", 20);
        }

        Def = PlayerPrefs.GetInt("Def_Stat");
        if(HP <= 5){
            PlayerPrefs.SetInt("Def_Stat", 5);
        }

        Crit = PlayerPrefs.GetInt("Crit_Stat");
        if(Crit <= 1){
            PlayerPrefs.SetInt("Crit_Stat", 1);
        }

        Cdmg = PlayerPrefs.GetInt("Cdmg_Stat");
        if(Cdmg <= 3){
            PlayerPrefs.SetInt("Cdmg_Stat", 3);
        }

        Spd = PlayerPrefs.GetInt("Spd_Stat");
        if(Spd <= 10){
            PlayerPrefs.SetInt("Spd_Stat", 10);
        }
    }

    void Update()
    {
        // Image
        tatakaeCharacter = character.sprite;
        playerPicture.sprite = character.sprite;
        playerPictureStat.sprite = character.sprite;
        playerPictureStatReflection.sprite = character.sprite;
        playerPictureCostume.sprite = character.sprite;
        playerPictureCostumeReflection.sprite = character.sprite;
        playerPictureEvolve.sprite = character.sprite;

        // Max C%
        if(Crit >= 100){
            Crit = 100;
        }

        // Profile Stat Text
        HP = PlayerPrefs.GetInt("HP_Stat");
        Convert(HP);
        Text_HP.text = AllNotation.AfterNotation;

        Atk = PlayerPrefs.GetInt("Atk_Stat");
        Convert(Atk);
        Text_Atk.text = AllNotation.AfterNotation;

        Def = PlayerPrefs.GetInt("Def_Stat");
        Convert(Def);
        Text_Def.text = AllNotation.AfterNotation;

        Crit = PlayerPrefs.GetInt("Crit_Stat");
        Text_Crit.text = Crit + "%";

        Cdmg = PlayerPrefs.GetInt("Cdmg_Stat");
        Convert(Cdmg);
        Text_Cdmg.text = AllNotation.AfterNotation;

        Spd = PlayerPrefs.GetInt("Spd_Stat");
        Convert(Spd);
        Text_Spd.text = AllNotation.AfterNotation;


        //PlayerPrefs
        level = PlayerPrefs.GetInt("Level");
        current_EXP = PlayerPrefs.GetInt("Current_EXP");
        temp_max_EXP = 500 * Mathf.Pow(level, 0.8f);
        max_EXP = (int)temp_max_EXP;
        PlayerPrefs.SetInt("Max_EXP", max_EXP);
        coin = PlayerPrefs.GetInt("Coin");
        ichor = PlayerPrefs.GetInt("Ichor");

        // EXP Text
        Text_level.text = "Lvl " + level;
        Convert(current_EXP);
        tempEXP = AllNotation.AfterNotation;
        Convert(max_EXP);
        EXP.text = tempEXP + "/" + AllNotation.AfterNotation;

        // EXP Slider
        EXP_Slider.maxValue = max_EXP;
        EXP_Slider.value = current_EXP;

        // Evolution Text (ganti warna teks jadi merah jika rss tidak cukup)                    
        if(level <= Evolution[PlayerPrefs.GetInt("EvoLevel")] && PlayerPrefs.GetInt("Current_EXP") < PlayerPrefs.GetInt("Max_EXP")){
            Evolution_Text_Level1.color = Color.red;
            Evolution_Text_Level2.color = Color.red;
        }
        else{
            Evolution_Text_Level1.color = Color.black;
            Evolution_Text_Level2.color = Color.black;
        }

        if(coin < coin_price[PlayerPrefs.GetInt("EvoLevel")]){
            Evolution_Coin.color = Color.red;
        }
        else{
            Evolution_Coin.color = Color.black;
        }

        if(ichor < ichor_price[PlayerPrefs.GetInt("EvoLevel")]){
            Evolution_Ichor.color = Color.red;
        }
        else{
            Evolution_Ichor.color = Color.black;
        }

        // Check if Evolution possible
        if(level <= Evolution[PlayerPrefs.GetInt("EvoLevel")] && PlayerPrefs.GetInt("Current_EXP") < PlayerPrefs.GetInt("Max_EXP")){
            Evolution_Button.interactable = false;
            CanEvoNotif.gameObject.SetActive(false);
            CanEvoNotifHome.gameObject.SetActive(false);
        }
        else if(coin < coin_price[PlayerPrefs.GetInt("EvoLevel")]){
            Evolution_Button.interactable = false;
            CanEvoNotif.gameObject.SetActive(false);
            CanEvoNotifHome.gameObject.SetActive(false);
        }
        else if(ichor < ichor_price[PlayerPrefs.GetInt("EvoLevel")]){
            Evolution_Button.interactable = false;
            CanEvoNotif.gameObject.SetActive(false);
            CanEvoNotifHome.gameObject.SetActive(false);
        }
        else{
            Evolution_Button.interactable = true;
            CanEvoNotif.gameObject.SetActive(true);
            CanEvoNotifHome.gameObject.SetActive(true);
        }

        if(ichor_price[PlayerPrefs.GetInt("EvoLevel")] == 0){
            Ichor_Box.SetActive(false);
        }
        else{
            Ichor_Box.SetActive(true);
        }

        // Evolution Text
        Evolution_Text_Level1.text = "" + Evolution[PlayerPrefs.GetInt("EvoLevel")];
        Convert(coin_price[PlayerPrefs.GetInt("EvoLevel")]);
        Evolution_Coin.text = AllNotation.AfterNotation;
        Convert(ichor_price[PlayerPrefs.GetInt("EvoLevel")]);
        Evolution_Ichor.text = AllNotation.AfterNotation;

        // Max Badge Rank = level 24
        if(PlayerPrefs.GetInt("Badge") >= 23){
            Evolution_Button_Menu.interactable = false;
        }


        // Battle Power
        BattlePower = PlayerPrefs.GetInt("HP_Stat");
        BattlePower += 2 * PlayerPrefs.GetInt("Atk_Stat");
        BattlePower += 2 * PlayerPrefs.GetInt("Def_Stat");
        BattlePower += 2 * PlayerPrefs.GetInt("Cdmg_Stat");
        BattlePower += 10 * PlayerPrefs.GetInt("Spd_Stat");

        BattlePower += BattlePower * PlayerPrefs.GetInt("Crit_Stat")/10;
        Convert(BattlePower);
        Text_BattlePower.text = AllNotation.AfterNotation;

    }

    // Evolution Button command
    public void DoEvolution(){
        PlayerPrefs.SetInt("Current_EXP" , 0);

        temp = PlayerPrefs.GetInt("Coin");
        temp -= coin_price[PlayerPrefs.GetInt("EvoLevel")];
        PlayerPrefs.SetInt("Coin", temp);

        temp = PlayerPrefs.GetInt("Ichor");
        temp -= ichor_price[PlayerPrefs.GetInt("EvoLevel")];
        PlayerPrefs.SetInt("Ichor", temp);

        temp = PlayerPrefs.GetInt("EvoLevel");
        temp += 1;
        PlayerPrefs.SetInt("EvoLevel", temp);

        temp = PlayerPrefs.GetInt("Badge");
        temp += 1;
        PlayerPrefs.SetInt("Badge", temp);

        temp = PlayerPrefs.GetInt("Level");
        temp += 1;
        PlayerPrefs.SetInt("Level", temp);

        // Evolution text
                // Before evo
        Convert(HP);
        Text_hp.text = AllNotation.AfterNotation;
        Convert(Atk);
        Text_atk.text = AllNotation.AfterNotation;
        Convert(Def);
        Text_def.text = AllNotation.AfterNotation;
        Text_crit.text = Crit + "%";
        Convert(Cdmg);
        Text_cdmg.text = AllNotation.AfterNotation;
        Convert(Spd);
        Text_spd.text = AllNotation.AfterNotation;

                // After Evo
        new_hp = PlayerPrefs.GetInt("HP_Stat") * 2;
        PlayerPrefs.SetInt("HP_Stat", new_hp);
        Convert(new_hp);
        Text_new_hp.text = AllNotation.AfterNotation;

        new_atk = PlayerPrefs.GetInt("Atk_Stat") * 2;
        PlayerPrefs.SetInt("Atk_Stat", new_atk);
        Convert(new_atk);
        Text_new_atk.text = AllNotation.AfterNotation;

        new_def = PlayerPrefs.GetInt("Def_Stat") * 2;
        PlayerPrefs.SetInt("Def_Stat", new_def);
        Convert(new_def);
        Text_new_def.text = AllNotation.AfterNotation;

        new_cdmg = PlayerPrefs.GetInt("Cdmg_Stat") * 2;
        PlayerPrefs.SetInt("Cdmg_Stat", new_cdmg);
        Convert(new_cdmg);
        Text_new_cdmg.text = AllNotation.AfterNotation;

        new_crit = PlayerPrefs.GetInt("Crit_Stat") + 5;
        if(new_crit >= 100){
            new_crit = 100;
        }
        PlayerPrefs.SetInt("Crit_Stat", new_crit);
        Convert(new_crit);
        Text_new_crit.text = AllNotation.AfterNotation + "%";

        new_spd = PlayerPrefs.GetInt("Spd_Stat") + 20;
        PlayerPrefs.SetInt("Spd_Stat", new_spd);
        Convert(new_spd);
        Text_new_spd.text = AllNotation.AfterNotation;
        
        // Succes Notification
        EvolutionSuccess.gameObject.SetActive(true);
        StartCoroutine(StatSuccessWindow());
    }

    public void BadgeUpdate(){
        BadgeImage.sprite = BadgeSprite[PlayerPrefs.GetInt("Badge")];
    }

    IEnumerator StatSuccessWindow()
    {
        yield return new WaitForSeconds(6.3f);
        SuccessWindow.gameObject.SetActive(true);
    }

    public void SkinGreen()
    {
        character.sprite = skinGreen.sprite;
        SkinID = 0;
    }

    public void SkinBlue()
    {
        character.sprite = skinBlue.sprite;
        SkinID = 1;
    }

    public void SkinPink()
    {
        character.sprite = skinPink.sprite;
        SkinID = 2;
    }

    public void SkinYellow()
    {
        character.sprite = skinYellow.sprite;
        SkinID = 3;
    }

    public void SkinBlack()
    {
        character.sprite = skinBlack.sprite;
        SkinID = 4;
    }

    public void SkinSilver()
    {
        character.sprite = skinSilver.sprite;
        SkinID = 5;
    }

    public void SkinGold()
    {
        character.sprite = skinGold.sprite;
        SkinID = 6;
    }

    public void SkinNoSignal()
    {
        character.sprite = skinNoSignal.sprite;
        SkinID = 7;
    }

    public static void NerfStat(){
        HP_nerfed = PlayerPrefs.GetInt("HP_Stat");
        Atk_nerfed = PlayerPrefs.GetInt("Atk_Stat");
        Def_nerfed = PlayerPrefs.GetInt("Def_Stat");
        Crit_nerfed = PlayerPrefs.GetInt("Crit_Stat");
        Cdmg_nerfed = PlayerPrefs.GetInt("Cdmg_Stat");
        Spd_nerfed = PlayerPrefs.GetInt("Spd_Stat");

        // Switch After Nerf
        switch(GameMechanic.currentHunger){
            case <= 25:
                HP_nerfed = PlayerPrefs.GetInt("HP_Stat") * 3 / 4;
                Atk_nerfed = PlayerPrefs.GetInt("Atk_Stat") * 3 / 4;
                break;
        }

        switch(GameMechanic.currentFun){
            case <= 25:
                Crit_nerfed = PlayerPrefs.GetInt("Crit_Stat") * 3 / 4;
                break;
        }

        switch(GameMechanic.currentStamina){
            case <= 25:
                Spd_nerfed = PlayerPrefs.GetInt("Spd_Stat") * 3 / 4;
                break;
        }
    }
}
