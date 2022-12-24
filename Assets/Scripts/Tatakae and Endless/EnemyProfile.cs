using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static AllNotation;

public class EnemyProfile : MonoBehaviour
{
    // Variable for NormalMode
    public static int HP = 10;
    public static int Atk = 3;
    public static int Def = 1;
    public static int Crit = 1;
    public static int Cdmg = 3;
    public static int Spd = 1;
    public static int CoinDrop = 12;
    public static int EXPDrop = 20;

    // Variable for EndlessMode
    public static int temp_HP = 40;
    public static int temp_Atk = 5;
    public static int temp_Def = 1;
    public static int temp_Crit = 1;
    public static int temp_Cdmg = 4;
    public static int temp_Spd = 1;
    public static int temp_CoinDrop = 9;
    public static int temp_EXPDrop = 15;

    public static float RNG;
    public static float RawStat;
    public static int FinalStat;

    public Image Image1;
    public Image Image2;
    public Image Image3;
    public Image Image4;

    public Text Text_HP;
    public Text Text_Atk;
    public Text Text_Def;
    public Text Text_Crit;
    public Text Text_Cdmg;
    public Text Text_Spd;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Image sprite
        Image1.sprite = Image2.sprite;
        Image3.sprite = Image2.sprite;
        Image4.sprite = Image2.sprite;

        // Max Crit Chance (100%)
        if(Crit >= 100)
            Crit = 100;

        // Enemy Stat (Text)
        Convert(HP);
        Text_HP.text = AllNotation.AfterNotation;
        Convert(Atk);
        Text_Atk.text = AllNotation.AfterNotation;
        Convert(Def);
        Text_Def.text = AllNotation.AfterNotation;
        Text_Crit.text = Crit + "%";
        Convert(Cdmg);
        Text_Cdmg.text = AllNotation.AfterNotation;
        Convert(Spd);
        Text_Spd.text = AllNotation.AfterNotation;
    }

    public static void NextStage(){
        //HP
        RNG = Random.Range(0.05f,0.3f);
        RawStat = RNG * HP;
        FinalStat = (int)RawStat;
        HP += FinalStat;

        if(TawuranSimulator.EnemyLeft <= 0){
            HP += 5*FinalStat;     
        }

        //Atk
        RNG = Random.Range(0.02f,0.3f);
        RawStat = RNG * Atk;
        FinalStat = (int)RawStat;
        Atk += FinalStat;

        if(TawuranSimulator.EnemyLeft <= 0){
            Atk += 5*FinalStat;     
        }

        //Def
        RNG = Random.Range(0.05f,0.2f);
        RawStat = RNG * Def;
        FinalStat = (int)RawStat;
        Def += FinalStat;

        if(TawuranSimulator.EnemyLeft <= 0){
            Def += 5*FinalStat;     
        }
        
        // Crit

        //Cdmg
        RNG = Random.Range(0.1f,0.4f);
        RawStat = RNG * Cdmg;
        FinalStat = (int)RawStat;
        Cdmg += FinalStat;

        if(TawuranSimulator.EnemyLeft <= 0){
            Cdmg += 5*FinalStat;     
        }

        //Spd
        RNG = Random.Range(0.02f,0.2f);
        RawStat = RNG * Spd;
        FinalStat = (int)RawStat;
        Spd += FinalStat;

        if(TawuranSimulator.EnemyLeft <= 0){
            Spd += 5*FinalStat;     
        }

        //Coin Drop
        RNG = Random.Range(0.05f,0.2f);
        RawStat = RNG * CoinDrop;
        FinalStat = (int)RawStat;
        CoinDrop += FinalStat;

        if(TawuranSimulator.EnemyLeft <= 0){
            CoinDrop += 5*FinalStat;     
        }

        // EXP
        RNG = Random.Range(0.05f,0.2f);
        RawStat = RNG * CoinDrop;
        FinalStat = (int)RawStat;
        EXPDrop += FinalStat;

        if(TawuranSimulator.EnemyLeft <= 0){
            EXPDrop += 5*FinalStat;     
        }
    }

    public static void NormalEnemyEvolution(){
        //HP
        RawStat = 10 * PlayerProfile.CurrentFloor * 1.2f;
        FinalStat = (int)RawStat;
        HP = FinalStat;

        //Atk
        RawStat = 5 * PlayerProfile.CurrentFloor * 1.2f;
        FinalStat = (int)RawStat;
        Atk = FinalStat;

        //Def
        RawStat = 3 * PlayerProfile.CurrentFloor * 1.2f;
        FinalStat = (int)RawStat;
        Def = FinalStat;

        //Crit
        Crit = 1 * PlayerProfile.CurrentFloor;

        //Cdmg
        RawStat = 3 * PlayerProfile.CurrentFloor * 1.2f;
        FinalStat = (int)RawStat;
        Cdmg = FinalStat;

        //Spd
        RawStat = 2 * PlayerProfile.CurrentFloor * 1.2f;
        FinalStat = (int)RawStat;
        Spd = FinalStat;

        //Coin Drop
        RawStat = 8 * PlayerProfile.CurrentFloor * 1.2f;
        FinalStat = (int)RawStat;
        CoinDrop = FinalStat;

        //EXP Drop
        RawStat = 8 * PlayerProfile.CurrentFloor * 1.2f;
        FinalStat = (int)RawStat;
        EXPDrop = FinalStat;
    }

    // Endless Next Stage and Boss Stat
    public static void EndlessNextStage(){
        //HP
        RNG = Random.Range(0.05f,0.3f);
        RawStat = RNG * HP;
        FinalStat = (int)RawStat;
        HP += FinalStat;

        if(EndlessMode.EnemyLeft <= 0){
            HP += 5*FinalStat;     
        }

        //Atk
        RNG = Random.Range(0.02f,0.3f);
        RawStat = RNG * Atk;
        FinalStat = (int)RawStat;
        Atk += FinalStat;

        if(EndlessMode.EnemyLeft <= 0){
            Atk += 5*FinalStat;     
        }

        //Def
        RNG = Random.Range(0.05f,0.2f);
        RawStat = RNG * Def;
        FinalStat = (int)RawStat;
        Def += FinalStat;

        if(EndlessMode.EnemyLeft <= 0){
            Def += 5*FinalStat;     
        }

        //Crit (Nothing change)

        //Cdmg
        RNG = Random.Range(0.1f,0.4f);
        RawStat = RNG * Cdmg;
        FinalStat = (int)RawStat;
        Cdmg += FinalStat;

        if(EndlessMode.EnemyLeft <= 0){
            Cdmg += 5*FinalStat;     
        }

        //Spd
        RNG = Random.Range(0.02f,0.2f);
        RawStat = RNG * Spd;
        FinalStat = (int)RawStat;
        Spd += FinalStat;

        if(EndlessMode.EnemyLeft <= 0){
            Spd += 5*FinalStat;     
        }

        //Coin Drop
        RNG = Random.Range(0.05f,0.2f);
        RawStat = RNG * CoinDrop;
        FinalStat = (int)RawStat;
        CoinDrop += FinalStat;

        if(EndlessMode.EnemyLeft <= 0){
            CoinDrop += 5 * FinalStat;
        }

        //EXP Drop
        RNG = Random.Range(0.05f,0.1f);
        RawStat = RNG * CoinDrop;
        FinalStat = (int)RawStat;
        EXPDrop += FinalStat;

        if(EndlessMode.EnemyLeft <= 0){
            EXPDrop += 5*FinalStat;
        }
    }

    // Endless Base Stat (First Enemy)
    public static void EnemyEvolution(){
        //HP
        RawStat = temp_HP * PlayerProfile.EndlessFloor * 1.2f;
        FinalStat = (int)RawStat;
        HP = FinalStat;

        //Atk
        RawStat = temp_Atk * PlayerProfile.EndlessFloor * 1.2f;
        FinalStat = (int)RawStat;
        Atk = FinalStat;

        //Def
        RawStat = temp_Def * PlayerProfile.EndlessFloor * 1.2f;
        FinalStat = (int)RawStat;
        Def = FinalStat;

        //Crit
        Crit = temp_Crit * PlayerProfile.EndlessFloor;

        //Cdmg
        RawStat = temp_Crit * PlayerProfile.EndlessFloor * 1.2f;
        FinalStat = (int)RawStat;
        Cdmg = FinalStat;

        //Spd
        RawStat = temp_Spd * PlayerProfile.EndlessFloor * 1.2f;
        FinalStat = (int)RawStat;
        Spd = FinalStat;

        //Coin Drop
        RawStat = temp_CoinDrop * PlayerProfile.EndlessFloor * 1.2f;
        FinalStat = (int)RawStat;
        CoinDrop = FinalStat;

        //EXP Drop
        RawStat = temp_EXPDrop * PlayerProfile.EndlessFloor * 1.2f;
        FinalStat = (int)RawStat;
        EXPDrop = FinalStat;
    }
}
