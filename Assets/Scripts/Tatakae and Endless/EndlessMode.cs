using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static AllNotation;

public class EndlessMode : MonoBehaviour
{
    public static int TotalDamagePlayer;
    public static int TotalDamageEnemy;
    public int AtkRNG;
    public int AtkRNG2;
    public int CritRNG;
    public int CritRNG2;
    public float Spd;
    public float Spd2;
    public int Checkpoint;

    public static bool MaxSize;

    // Enemy Left Icon
    public Text EnemyLeftText;
    public static int EnemyLeft;
    public Image EnemyLeftIcon;
    public GameObject EnemyLeftBorder;

    // Coin
    public int CoinGet;
    public int Current_Coin;
    public static float TotalCoin;
    public Text CoinText;
    public Text FinalCoinText;

    // Ruby
    public int RandomRuby;
    public int CurrentRuby;
    public int TotalRuby;
    public Text RubyText;
    public Text FinalRubyText;

    // EXP
    public int current_EXP;

    // Slash Effect
    public GameObject SlashEffect;

    // Damage Text
    public GameObject DamageTextObject;
    public static bool CritText;

    // LevelUP
    public GameObject LevelUPNotify;

    // Stamina
    public int Stamina;
    public Text StaminaTotal;

    // Win and Lose Notification
    public GameObject LoseWindow;
    public GameObject EnemyProfileWindow;

    // Floor and Boss Notification
    public GameObject BossAlert;
    public GameObject FloorAlert_GameObject;
    public Text FloorAlert_Text;

    // Endless Mode
    public int TotalKill;

    // Audio and Picture
    public Image Enemy;
    public Image Player;
    public AudioSource HitSFX;
    public AudioClip[] HitSound;
    public AudioClip[] CritSound;
    public AudioClip[] EnemyHitSound;
    public AudioClip[] EnemyCritSound;
    public Sprite[] EnemyList;

    // Start is called before the first frame update
    void Start(){
        Stamina = 0;
        TotalCoin = 0;
        TotalRuby = 0;
        EnemyLeft = 10;
        MaxSize = false;

        PlayerProfile.CurrentFloor = PlayerPrefs.GetInt("Floor");

        if(PlayerPrefs.GetInt("Checkpoint_Save") < 10){
            PlayerPrefs.SetInt("Checkpoint_Save", 1);
        }
        PlayerProfile.EndlessFloor = PlayerPrefs.GetInt("Checkpoint_Save");

        // Set Enemy stat depend on the floor
        EnemyProfile.EnemyEvolution();
        HP_Filler.Enemy_currentHP = EnemyProfile.temp_HP;

        RandomEnemy();

        StartCoroutine(FloorAlert());
        StartCoroutine(StartGame());
    }

    // Update is called once per frame
    void Update(){
        // Player Stat Update
        PlayerProfile.HP = PlayerPrefs.GetInt("HP_Stat");
        PlayerProfile.Atk_nerfed = PlayerPrefs.GetInt("Atk_Stat");
        PlayerProfile.Def_nerfed = PlayerPrefs.GetInt("Def_Stat");
        PlayerProfile.Crit_nerfed = PlayerPrefs.GetInt("Crit_Stat");
        PlayerProfile.Cdmg_nerfed = PlayerPrefs.GetInt("Cdmg_Stat");
        PlayerProfile.Spd = PlayerPrefs.GetInt("Spd_Stat");

        if(HP_Filler.currentHP <= 0){
            EndRound();
        }

        if(HP_Filler.currentHP > 0 && HP_Filler.Enemy_currentHP <= 0){
            Victory();
        }

        // Set Text
        StaminaTotal.text = "" + Stamina;
        Convert(TotalCoin);
        CoinText.text = AllNotation.AfterNotation;
        FinalCoinText.text = AllNotation.AfterNotation;
        Convert(TotalRuby);
        RubyText.text = AllNotation.AfterNotation;
        FinalRubyText.text = AllNotation.AfterNotation;
        EnemyLeftText.text = "" + EnemyLeft;

        // Set Enemy Icon Left
        if(EnemyLeft == 1){
            EnemyLeftText.gameObject.SetActive(false);
            EnemyLeftIcon.color = Color.red;
        }
        else if(EnemyLeft <= 0 ){
            EnemyLeftIcon.gameObject.SetActive(false);
            EnemyLeftBorder.gameObject.SetActive(false);
            Enemy.rectTransform.sizeDelta = new Vector2(350, 350);

            if(!MaxSize){
                Enemy.rectTransform.anchoredPosition = new Vector2(Enemy.rectTransform.anchoredPosition.x, Enemy.rectTransform.anchoredPosition.y-100);
                StartCoroutine(DeleteBossAlert());  

                MaxSize = true;
            }
        }

        // Checkpoint Set
        if(PlayerProfile.EndlessFloor % 10 == 1 && PlayerProfile.EndlessFloor > 10){
            Checkpoint = PlayerProfile.EndlessFloor;
            PlayerPrefs.SetInt("Checkpoint_Save", Checkpoint);
        }
    }

    // Blink Animation
    void EnemyBlinking(){
        StartCoroutine(EnemyBlinkAnimation());
    }

    void PlayerBlinking(){
        StartCoroutine(PlayerBlinkAnimation());
    }

    IEnumerator EnemyBlinkAnimation(){
        Enemy.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        Enemy.color = Color.white;
        yield return new WaitForSeconds(0.1f);
        Enemy.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        Enemy.color = Color.white;
        yield return new WaitForSeconds(0.1f);
        Enemy.color = Color.red;
        yield return new WaitForSeconds(0.15f);
        Enemy.color = Color.white;
        yield return new WaitForSeconds(0.15f);
        Enemy.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        Enemy.color = Color.white;
        yield return new WaitForSeconds(0.2f);
        StopCoroutine(EnemyBlinkAnimation());
    }

    IEnumerator PlayerBlinkAnimation(){
        Player.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        Player.color = Color.white;
        yield return new WaitForSeconds(0.1f);
        Player.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        Player.color = Color.white;
        yield return new WaitForSeconds(0.1f);
        Player.color = Color.red;
        yield return new WaitForSeconds(0.15f);
        Player.color = Color.white;
        yield return new WaitForSeconds(0.15f);
        Player.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        Player.color = Color.white;
        yield return new WaitForSeconds(0.2f);
        StopCoroutine(PlayerBlinkAnimation());
    }

    // Boss Alert
    IEnumerator DeleteBossAlert(){
        BossAlert.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        BossAlert.gameObject.SetActive(false);
        yield return new WaitForSeconds(.1f);
        StopCoroutine(DeleteBossAlert());
    }

    // New Floor Alert
    IEnumerator FloorAlert(){
        // Save Highest Floor
        if(PlayerProfile.EndlessFloor >= PlayerPrefs.GetInt("HighestEndlessFloor_Save"))
        {
            PlayerPrefs.SetInt("HighestEndlessFloor_Save", PlayerProfile.EndlessFloor);
        }

        // Notification
        FloorAlert_Text.text = "" + PlayerProfile.EndlessFloor;
        FloorAlert_GameObject.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        FloorAlert_GameObject.gameObject.SetActive(false);
        yield return new WaitForSeconds(.1f);
        StopCoroutine(FloorAlert());
    }
    

    void PlayerAtk(){
        if(HP_Filler.currentHP > 0 && HP_Filler.Enemy_currentHP > 0){
            CritRNG = Random.Range(1,100);
            AtkRNG = Random.Range(0,PlayerProfile.Atk_nerfed/3);

            if(CritRNG <= PlayerProfile.Crit_nerfed){
                TotalDamagePlayer = PlayerProfile.Atk_nerfed + AtkRNG + PlayerProfile.Cdmg_nerfed - EnemyProfile.Def;
                HitSFX.PlayOneShot(CritSound[Random.Range(0, CritSound.Length)], 1f);
                CritText = true;
            }
            else{
                TotalDamagePlayer = PlayerProfile.Atk_nerfed + AtkRNG - EnemyProfile.Def;
                HitSFX.PlayOneShot(HitSound[Random.Range(0, HitSound.Length)], 1f);
                CritText = false;
            }

            if(TotalDamagePlayer <= 0){
                TotalDamagePlayer = 1;
            }

            HP_Filler.Enemy_currentHP -= TotalDamagePlayer;

            Instantiate(DamageTextObject, transform.position, transform.rotation);
            Instantiate(SlashEffect, transform.position, transform.rotation);

            // LevelUP
            if(LevelUP_Script.Leveledup == true){
                LevelUPNotify.gameObject.SetActive(true);
                StartCoroutine(LevelUpoff());
            }else{
                LevelUPNotify.gameObject.SetActive(false);
            }
        }
    }

    void EnemyAtk(){
        if(HP_Filler.currentHP > 0 && HP_Filler.Enemy_currentHP > 0){
            CritRNG2 = Random.Range(1,100);
            AtkRNG2 = Random.Range(0,EnemyProfile.Atk/3);

            if(CritRNG2 <= EnemyProfile.Crit){
                TotalDamageEnemy = EnemyProfile.Atk + AtkRNG2 + EnemyProfile.Cdmg - PlayerProfile.Def_nerfed;
                HitSFX.PlayOneShot(EnemyCritSound[Random.Range(0, EnemyCritSound.Length)], 1f);
            }
            else{
                TotalDamageEnemy = EnemyProfile.Atk + AtkRNG2 - PlayerProfile.Def_nerfed;
                HitSFX.PlayOneShot(EnemyHitSound[Random.Range(0, EnemyHitSound.Length)], 1f);
            } 

            if(TotalDamageEnemy <= 0){
                TotalDamageEnemy = 1;
            }

            HP_Filler.currentHP -= TotalDamageEnemy;
        }
    }

    void Victory(){
        if(EnemyLeft >= 0){
            EnemyLeft -= 1;

            if(EnemyLeft < 0){
                // Coin Drop
                TotalCoin += 2 * EnemyProfile.CoinDrop;
                GameMechanic.Coin += 2 * EnemyProfile.CoinDrop;
                PlayerPrefs.SetInt("Coin", (int)GameMechanic.Coin);

                // Ruby Drop
                RandomRuby = Random.Range(20,50);
                CurrentRuby = PlayerPrefs.GetInt("Ruby");
                CurrentRuby += RandomRuby;
                PlayerPrefs.SetInt("Ruby", CurrentRuby);
                TotalRuby += RandomRuby;

                // EXP
                current_EXP = PlayerPrefs.GetInt("Current_EXP");
                current_EXP += 2 *  EnemyProfile.EXPDrop;
                PlayerPrefs.SetInt("Current_EXP", current_EXP);

                LevelUP_Script.isLevelUP();

                Reset();
            }
            else{
                // Coin Drop
                Current_Coin = PlayerPrefs.GetInt("Coin");
                CoinGet = EnemyProfile.CoinDrop;
                Current_Coin += CoinGet;
                PlayerPrefs.SetInt("Coin", Current_Coin);
                TotalCoin += CoinGet;
                GameMechanic.Coin += CoinGet;   

                // Ruby Drop
                RandomRuby = Random.Range(1,4);
                if(RandomRuby == 1){
                    RandomRuby = Random.Range(1,10);
                    CurrentRuby = PlayerPrefs.GetInt("Ruby");
                    CurrentRuby += RandomRuby;
                    PlayerPrefs.SetInt("Ruby", CurrentRuby);
                    TotalRuby += RandomRuby;
                }

                // EXP
                current_EXP = PlayerPrefs.GetInt("Current_EXP");
                current_EXP += EnemyProfile.EXPDrop;
                PlayerPrefs.SetInt("Current_EXP", current_EXP);

                LevelUP_Script.isLevelUP();
            }

            // Next Stage
            EnemyBlinking();
            EnemyProfile.EndlessNextStage();
            HP_Filler.Enemy_currentHP = EnemyProfile.HP;
            HP_Filler.Enemy_maxHP = EnemyProfile.HP;
            RandomEnemy();
        }
    }

    void EndRound(){
        if(Stamina <= 0){
            EndGameLose();
        }
        else{
            Stamina -= 1;
            PlayerBlinking();
            HP_Filler.currentHP = HP_Filler.maxHP;
        }
    }

    void EndGameLose(){
        EnemyProfileWindow.gameObject.SetActive(false);
        LoseWindow.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    void RandomEnemy(){
        if(PlayerProfile.CurrentFloor <= 10){
            Enemy.sprite = EnemyList[Random.Range(0, 4)]; 
        }
        else if(PlayerProfile.CurrentFloor <= 20){
            Enemy.sprite = EnemyList[Random.Range(0, 10)]; 
        }
    }

    void Reset(){
        // Enemy Size
        Enemy.rectTransform.sizeDelta = new Vector2(250, 250);
        Enemy.rectTransform.anchoredPosition = new Vector2(Enemy.rectTransform.anchoredPosition.x, Enemy.rectTransform.anchoredPosition.y+100);
        
        // Enemy Left Info
        EnemyLeft = 10;
        EnemyLeftIcon.gameObject.SetActive(true);
        EnemyLeftBorder.gameObject.SetActive(true);
        EnemyLeftText.gameObject.SetActive(true);
        EnemyLeftIcon.color = Color.black;

        // Floor Text
        PlayerProfile.EndlessFloor += 1;
        StartCoroutine(FloorAlert());
        BossAlert.gameObject.SetActive(false);

        // Enemy Evo
        EnemyProfile.EnemyEvolution();
        MaxSize = false;
    }

    IEnumerator StartGame(){
        yield return new WaitForSeconds(2f);
        
        Spd = 1.5f - (PlayerProfile.Spd * 0.01f);
        if(Spd <= 0.3f){
            Spd = 0.3f;
        }

        Spd2 = 1.5f - (EnemyProfile.Spd * 0.01f);
        if(Spd2 <= 0.3f){
            Spd2 = 0.3f;
        }

        InvokeRepeating("PlayerAtk", 0f, Spd);
        InvokeRepeating("EnemyAtk", 0f, Spd2);
        StopCoroutine(StartGame());
    }

    // Level Up Notif
    IEnumerator LevelUpoff()
    {
        yield return new WaitForSeconds(.5f);
        LevelUP_Script.Leveledup = false;
    }
}
