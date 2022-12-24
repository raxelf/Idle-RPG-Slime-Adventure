using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static AllNotation;

public class BossProfile : MonoBehaviour
{
    public static int TrueAtk;
    public static int Def;
    public static int Spd;

    // Boss Image
    public Image BossImage;
    public Image BossProfileImage;
    public Text BossName;

    public GameObject Boss1;
    public Sprite Boss1_Image;

    public GameObject Boss2;
    public Sprite Boss2_Image;

    public GameObject Boss3;
    public Sprite Boss3_Image;

    public Text TrueAtk_Text;
    public Text Def_Text;
    public Text Spd_Text;

    public static int BossLevel = 3;
    public static float ScoreMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        switch (BossLevel)
        {
            case 1:
            TrueAtk = 500;
            Def = 300;
            Spd = 30;
            ScoreMultiplier = 1;
            Boss1.SetActive(true);
            BossImage.sprite = Boss1_Image;
            BossProfileImage.sprite = Boss1_Image;
            BossName.text = "Jeki";
            break;

            case 2:
            TrueAtk = 5000;
            Def = 2000;
            Spd = 120;
            ScoreMultiplier = 2.5f;
            Boss2.SetActive(true);
            BossImage.sprite = Boss2_Image;
            BossProfileImage.sprite = Boss2_Image;
            BossName.text = "Alaska Worm";
            break;

            case 3:
            TrueAtk = 20000;
            Def = 10000;
            Spd = 250;
            ScoreMultiplier = 5;
            Boss3.SetActive(true);
            BossImage.sprite = Boss3_Image;
            BossProfileImage.sprite = Boss3_Image;
            BossName.text = "The Trimple";
            break;

            default:
            Debug.LogError("Something isn't right.");
            // TrueAtk = 500;
            // Def = 300;
            // Spd = 30;
            // ScoreMultiplier = 1;
            // Boss1.SetActive(true);
            // BossImage.sprite = Boss1_Image;
            // BossProfileImage.sprite = Boss1_Image;
            break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Convert(TrueAtk);
        TrueAtk_Text.text = AllNotation.AfterNotation;
        Convert(Def);
        Def_Text.text = AllNotation.AfterNotation;
        Convert(Spd);
        Spd_Text.text = AllNotation.AfterNotation;   
    }
}
