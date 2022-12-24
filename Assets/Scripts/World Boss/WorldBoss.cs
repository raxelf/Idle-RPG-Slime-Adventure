using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static AllNotation;

public class WorldBoss : MonoBehaviour
{
    public int TotalDamage;
    public Text TotalDamage_Text;
    public static int TotalDamagePlayer;
    public static int TotalDamageEnemy;
    public int AtkRNG;
    public int TrueAtk;
    public int TrueAtkRNG;
    public int CritRNG;
    public float Spd;
    public float Spd2;
    public float temp_float;

    // Jamur (Jeki)
    private float SomethingRNG;

    // Fire Worm
    public GameObject Explosive;
    public bool BossParticleEffect;

    // Big Eyes
    public GameObject BigEyes_Laser_GameObject;
    public Image BigEyes_Laser;
    public GameObject BigEyes_Burn;
    public GameObject BigEyes_CastParticle;
    public Image BigEyes_Image;

    private int temp;

    // Fight length
    public bool Timer;
    public bool TimerCountdown;
    public float TimerCount;
    public int TimerCountInt;
    public Text TimerText;

    // Final Result
    public Text Result_TotalDamage;
    public int TotalIchorDrop;
    public int TotalIchor;
    public Text Result_TotalIchor;

    // Slash Effect
    public GameObject SlashEffect;

    // Damage Text
    public GameObject DamageTextObject;
    public static bool CritText;

    // Stamina
    public int Stamina;
    public Text StaminaTotal;

    // Win and Lose Notification
    public GameObject LoseWindow;
    public GameObject EnemyProfileWindow;

    // Audio and Picture
    public Image Enemy;
    public Image Player;

    public AudioSource BGM;
    public AudioSource HitSFX;
    public AudioClip[] BossSound;
    public AudioClip[] FireWorm;
    public AudioClip[] BigEyes;
    public AudioClip[] HitSound;
    public AudioClip[] CritSound;
    public AudioClip[] EnemyHitSound;
    public AudioClip[] EnemyCritSound;

    // Start is called before the first frame update
    void Start(){
        Stamina = 0;
        TotalDamage = 0;
        TimerCount = 60;
        Timer = true;
        TimerCountdown = false;
        TotalIchor = 0;
        TotalIchorDrop = 0;
        TotalIchor = PlayerPrefs.GetInt("Ichor");   

        StartCoroutine(StartGame());
        switch(BossProfile.BossLevel)
        {
            case 1:
            BGM.PlayOneShot(BossSound[Random.Range(0, BossSound.Length)], 3f);   
            break;

            case 2:
            BGM.PlayOneShot(FireWorm[0], 1f); 
            break;

            case 3:
            BGM.PlayOneShot(BigEyes[0], 1f);
            break;

            default:
            BGM.PlayOneShot(BossSound[Random.Range(0, BossSound.Length)], 3f);   
            break;
        }
    }

    // Update is called once per frame
    void Update(){
        if(WorldBoss_HP.currentHP <= 0){
            EndRound();
        }

        Convert(TotalDamage);

        // Timer
        if(TimerCountdown){
            TimerCount -= 1 * Time.deltaTime;
            TimerCountInt = (int)TimerCount;
        }
        
        // Set Text
        StaminaTotal.text = "" + Stamina;
        TotalDamage_Text.text = AllNotation.AfterNotation;
        Convert(TotalDamage);
        Result_TotalDamage.text = AllNotation.AfterNotation;

        TotalIchorDrop = TotalDamage / 100;
        Convert(TotalIchorDrop);
        Result_TotalIchor.text = AllNotation.AfterNotation;

        TimerText.text = "" + (int)TimerCount;
    }

    // Blink Animation

    void PlayerBlinking(){
        StartCoroutine(PlayerBlinkAnimation());
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
    
    void PlayerAtk(){
        if(Timer){
            CritRNG = Random.Range(1,100);
            AtkRNG = Random.Range(0,PlayerProfile.Atk_nerfed/3);

            if(CritRNG <= PlayerProfile.Crit_nerfed){
                TotalDamagePlayer = PlayerProfile.Atk_nerfed + AtkRNG + PlayerProfile.Cdmg_nerfed - BossProfile.Def;
                HitSFX.PlayOneShot(CritSound[Random.Range(0, CritSound.Length)], 1f);
                CritText = true;
            }
            else{
                TotalDamagePlayer = PlayerProfile.Atk_nerfed + AtkRNG - BossProfile.Def;
                HitSFX.PlayOneShot(HitSound[Random.Range(0, HitSound.Length)], 1f);
                CritText = false;
            }

            if(TotalDamagePlayer <= 0){
                TotalDamagePlayer = 1;
            }

            temp_float = TotalDamagePlayer * BossProfile.ScoreMultiplier;
            TotalDamage += (int)temp_float;
            Instantiate(DamageTextObject, transform.position, transform.rotation);
            Instantiate(SlashEffect, transform.position, transform.rotation);
        }
    }

    void EnemyAtk(){
        if(Timer){
            TrueAtkRNG = Random.Range(0,1);
            if(TrueAtkRNG == 0){
                HitSFX.PlayOneShot(EnemyCritSound[Random.Range(0, EnemyCritSound.Length)], 1f);
            }
            else{
                HitSFX.PlayOneShot(EnemyHitSound[Random.Range(0, EnemyHitSound.Length)], 1f);
            }

            TotalDamageEnemy = BossProfile.TrueAtk;
        
            WorldBoss_HP.currentHP -= TotalDamageEnemy;
        }

        // Alaska Worm


        switch(BossProfile.BossLevel){
            case 2:
                if(TimerCountInt % 15 == 0 && TimerCountInt >= 15 && TimerCountInt <= 45 && !BossParticleEffect){
                BossParticleEffect = true;
                StartCoroutine(ExplosiveFireWorm());
                }
                break;

            case 3:
                if(TimerCountInt % 10 == 0 && TimerCountInt >= 10 && TimerCountInt <= 50 && !BossParticleEffect){
                BossParticleEffect = true;
                StartCoroutine(BigEyesLaser());
                }
                break;

        }
    }

    void EndRound(){
        if(Stamina <= 0){
            EndGameLose();
        }
        else{
            Stamina -= 1;
            PlayerBlinking();
            WorldBoss_HP.currentHP = WorldBoss_HP.maxHP;
        }
    }

    void EndGameLose(){
        EnemyProfileWindow.gameObject.SetActive(false);
        LoseWindow.gameObject.SetActive(true);

        temp = TotalIchor + TotalIchorDrop;
        PlayerPrefs.SetInt("Ichor", temp);
        Time.timeScale = 0f;

        if(WorldBoss_HP.currentHP > 0){
            switch(BossProfile.BossLevel){
                case 1:
                PlayerPrefs.SetInt("isWin1", 1);
                break;

                case 2:
                PlayerPrefs.SetInt("isWin2", 1);
                break;

                case 3:
                PlayerPrefs.SetInt("isWin3", 1);
                break;

                default:
                break;
            }
        }
    }

    IEnumerator StartGame(){
        yield return new WaitForSeconds(1f);
        
        Spd = 1.5f - (PlayerProfile.Spd * 0.01f);
        if(Spd <= 0.3f){
            Spd = 0.3f;
        }

        Spd2 = 1.5f - (BossProfile.Spd * 0.01f);
        if(Spd2 <= 0.3f){
            Spd2 = 0.3f;
        }

        TimerCountdown = true;

        InvokeRepeating("PlayerAtk", 0f, Spd);
        InvokeRepeating("EnemyAtk", 0f, Spd2);
        StartCoroutine(StartTimer());
        StopCoroutine(StartGame());
    }

    IEnumerator ExplosiveFireWorm(){
        Explosive.SetActive(true);
        Player.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        Player.color = Color.white;
        BGM.PlayOneShot(FireWorm[1], 1f); 
        WorldBoss_HP.currentHP -= BossProfile.TrueAtk * 20;

        yield return new WaitForSeconds(0.8f);
        BossParticleEffect = false;
        Explosive.SetActive(false);
        StartCoroutine(BurnFireWormEffect());
        StopCoroutine(ExplosiveFireWorm());
    }

    IEnumerator BurnFireWormEffect(){
        for(int i = 5; i > 0; i-- ){
            WorldBoss_HP.currentHP -= BossProfile.TrueAtk * 2;
            Player.color = Color.red;
            yield return new WaitForSeconds(0.2f);
            Player.color = Color.white;
            yield return new WaitForSeconds(0.8f);
        }

        StopCoroutine(BurnFireWormEffect());
    }

    IEnumerator BigEyesLaser(){
        // Spell Cast Animation
        BigEyes_CastParticle.SetActive(true);
        BGM.PlayOneShot(BigEyes[2], 1f);
        yield return new WaitForSeconds(1.5f);
        BigEyes_CastParticle.SetActive(false);

        // Laser animation
        BigEyes_Laser_GameObject.SetActive(true);
        StartCoroutine(BigEyesBurnAnimation());
        StartCoroutine(BigEyesLaserEffect());
        StartCoroutine(BigEyesLaserAnimation());
        yield return new WaitForSeconds(2f);
        BigEyes_Laser_GameObject.SetActive(false);

        BossParticleEffect = false;

        StopCoroutine(BigEyesLaser());
    }

    IEnumerator BigEyesBurnAnimation(){
        yield return new WaitForSeconds(0.2f);
        BigEyes_Burn.SetActive(true);
        yield return new WaitForSeconds(1.18f);
        BigEyes_Burn.SetActive(false);
        
        StopCoroutine(BigEyesBurnAnimation());
    }

    IEnumerator BigEyesLaserAnimation(){
        temp = 0;
        BGM.PlayOneShot(BigEyes[1], 1f);

        while(temp <= 60){
            temp += 2;

            BigEyes_Laser.rectTransform.sizeDelta = new Vector2(temp, 700);
            yield return new WaitForSeconds(0.01f);
        }
        StopCoroutine(BigEyesLaserAnimation());
    }

    IEnumerator BigEyesLaserEffect(){
        for(int i = 10; i > 0; i --){
            WorldBoss_HP.currentHP -= BossProfile.TrueAtk * 2;
            Player.color = Color.red;
            yield return new WaitForSeconds(0.1f);
            Player.color = Color.white;
            yield return new WaitForSeconds(0.1f);
        }

        StopCoroutine(BigEyesLaserEffect());
    }

    IEnumerator StartTimer(){
        yield return new WaitForSeconds(60f);
        Timer = false;

        EndGameLose();
        StopCoroutine(StartTimer());
    }
}
