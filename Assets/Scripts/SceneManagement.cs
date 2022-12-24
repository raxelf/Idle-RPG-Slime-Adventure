using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    // Warning
    public GameObject WarningWindow;
    public GameObject proceedAdv;
    public GameObject proceedEndless;
    public GameObject proceedWorldBoss1;
    public GameObject proceedWorldBoss2;
    public GameObject proceedWorldBoss3;
    public Text warningText1;
    public Text warningText2;

    // Reveal Boss
        // Boss 2
    public GameObject Boss2;
    public Image Boss2Image;
    public Text Level2;
    public Text BossName2;
    public Text BossMultiplier2;
        // Boss 3
    public GameObject Boss3;
    public Image Boss3Image;
    public Text Level3;
    public Text BossName3;
    public Text BossMultiplier3;

    // Current & Highest Floor
    public Text currentFloorText;
    public Text HighestFloorText;

    void Update()
    {
        // Current & Highest Floor Text
        currentFloorText.text = "Current Floor : " + PlayerPrefs.GetInt("Checkpoint_Save");
        HighestFloorText.text = "Highest : " + PlayerPrefs.GetInt("HighestEndlessFloor_Save");

        // Unlock Boss 2
        if(PlayerPrefs.GetInt("isWin1") == 1){
            Boss2.GetComponent<Button>().interactable = true;
            Boss2Image.color = new Color(255, 255, 255, 255);
            Level2.GetComponent<Text>().color = new Color(0, 0, 0, 255);
            BossName2.text = "Alaskan Worm";
            BossName2.GetComponent<Text>().color = new Color(0, 0, 0, 255);
            BossMultiplier2.text = "250%";
        }else{
            Boss2.GetComponent<Button>().interactable = false;
            Boss2Image.color = new Color(0, 0, 0, 255);
            BossName2.text = "???";
            BossMultiplier2.text = "???";
        }

        // Unlock Boss 3
        if(PlayerPrefs.GetInt("isWin2") == 1){
            Boss3.GetComponent<Button>().interactable = true;
            Boss3Image.color = new Color(255, 255, 255, 255);
            Level3.GetComponent<Text>().color = new Color(0, 0, 0, 255);
            BossName3.text = "The Trimple";
            BossName3.GetComponent<Text>().color = new Color(0, 0, 0, 255);
            BossMultiplier3.text = "500%";
        }else{
            Boss3.GetComponent<Button>().interactable = false;
            Boss3Image.color = new Color(0, 0, 0, 255);
            BossName3.text = "???";
            BossMultiplier3.text = "???";
        }
    }

    // Adventure
    public void GoAdventure()
    {
        // Warning before go
        if(GameMechanic.currentHunger <= 25 || GameMechanic.currentFun <= 25 || GameMechanic.currentStamina <= 25){
            WarningWindow.gameObject.SetActive(true);

            // Button
            proceedAdv.gameObject.SetActive(true);

            proceedEndless.gameObject.SetActive(false);
            proceedWorldBoss1.gameObject.SetActive(false);
            proceedWorldBoss2.gameObject.SetActive(false);
            proceedWorldBoss3.gameObject.SetActive(false);

            if(GameMechanic.currentHunger <= 25){
                warningText1.text = "Hunger";
                warningText2.text = "ATK";
            }
            if(GameMechanic.currentFun <= 25){
                warningText1.text = "Fun";
                warningText2.text = "CRIT";
            }
            if(GameMechanic.currentStamina <= 25){
                warningText1.text = "Energy";
                warningText2.text = "SPD";
            }
            if(GameMechanic.currentHunger <= 25 && GameMechanic.currentFun <= 25){
                warningText1.text = "Hunger & Fun";
                warningText2.text = "ATK & CRIT";
            }
            if(GameMechanic.currentHunger <= 25 && GameMechanic.currentStamina <= 25){
                warningText1.text = "Hunger & Energy";
                warningText2.text = "ATK & SPD";
            }
            if(GameMechanic.currentFun <= 25 && GameMechanic.currentStamina <= 25){
                warningText1.text = "Fun & Energy";
                warningText2.text = "CRIT & SPD";
            }
            if(GameMechanic.currentHunger <= 25 && GameMechanic.currentFun <= 25 && GameMechanic.currentStamina <= 25){
                warningText1.text = "Hunger, Fun & Energy";
                warningText2.text = "ATK, CRIT & SPD";
            }
        }else{
            SceneManager.LoadScene("TatakaeScene", LoadSceneMode.Single);
        }
    }


    // Endless
    public void GoEndless()
    {
        // Warning before go
        if(GameMechanic.currentHunger <= 25 || GameMechanic.currentFun <= 25 || GameMechanic.currentStamina <= 25){
            WarningWindow.gameObject.SetActive(true);

            // Button
            proceedEndless.gameObject.SetActive(true);

            proceedAdv.gameObject.SetActive(false);
            proceedWorldBoss1.gameObject.SetActive(false);
            proceedWorldBoss2.gameObject.SetActive(false);
            proceedWorldBoss3.gameObject.SetActive(false);

            if(GameMechanic.currentHunger <= 25){
                warningText1.text = "Hunger";
                warningText2.text = "ATK";
            }
            if(GameMechanic.currentFun <= 25){
                warningText1.text = "Fun";
                warningText2.text = "CRIT";
            }
            if(GameMechanic.currentStamina <= 25){
                warningText1.text = "Energy";
                warningText2.text = "SPD";
            }
            if(GameMechanic.currentHunger <= 25 && GameMechanic.currentFun <= 25){
                warningText1.text = "Hunger & Fun";
                warningText2.text = "ATK & CRIT";
            }
            if(GameMechanic.currentHunger <= 25 && GameMechanic.currentStamina <= 25){
                warningText1.text = "Hunger & Energy";
                warningText2.text = "ATK & SPD";
            }
            if(GameMechanic.currentFun <= 25 && GameMechanic.currentStamina <= 25){
                warningText1.text = "Fun & Energy";
                warningText2.text = "CRIT & SPD";
            }
            if(GameMechanic.currentHunger <= 25 && GameMechanic.currentFun <= 25 && GameMechanic.currentStamina <= 25){
                warningText1.text = "Hunger, Fun & Energy";
                warningText2.text = "ATK, CRIT & SPD";
            }
        }else{
            SceneManager.LoadScene("EndlessScene", LoadSceneMode.Single);
        }
    }


    // World Boss
    public void GoWorldBoss1()
    {
        // Warning before go
        if(GameMechanic.currentHunger <= 25 || GameMechanic.currentFun <= 25 || GameMechanic.currentStamina <= 25){
            WarningWindow.gameObject.SetActive(true);

            // Button
            proceedWorldBoss1.gameObject.SetActive(true);

            proceedEndless.gameObject.SetActive(false);
            proceedAdv.gameObject.SetActive(false);
            proceedWorldBoss2.gameObject.SetActive(false);
            proceedWorldBoss3.gameObject.SetActive(false);

            if(GameMechanic.currentHunger <= 25){
                warningText1.text = "Hunger";
                warningText2.text = "ATK";
            }
            if(GameMechanic.currentFun <= 25){
                warningText1.text = "Fun";
                warningText2.text = "CRIT";
            }
            if(GameMechanic.currentStamina <= 25){
                warningText1.text = "Energy";
                warningText2.text = "SPD";
            }
            if(GameMechanic.currentHunger <= 25 && GameMechanic.currentFun <= 25){
                warningText1.text = "Hunger & Fun";
                warningText2.text = "ATK & CRIT";
            }
            if(GameMechanic.currentHunger <= 25 && GameMechanic.currentStamina <= 25){
                warningText1.text = "Hunger & Energy";
                warningText2.text = "ATK & SPD";
            }
            if(GameMechanic.currentFun <= 25 && GameMechanic.currentStamina <= 25){
                warningText1.text = "Fun & Energy";
                warningText2.text = "CRIT & SPD";
            }
            if(GameMechanic.currentHunger <= 25 && GameMechanic.currentFun <= 25 && GameMechanic.currentStamina <= 25){
                warningText1.text = "Hunger, Fun & Energy";
                warningText2.text = "ATK, CRIT & SPD";
            }
        }else{
            SceneManager.LoadScene("WorldBossScene", LoadSceneMode.Single);
            BossProfile.BossLevel = 1;
        }
    }

    public void GoWorldBoss2()
    {
        // Warning before go
        if(GameMechanic.currentHunger <= 25 || GameMechanic.currentFun <= 25 || GameMechanic.currentStamina <= 25){
            WarningWindow.gameObject.SetActive(true);

            // Button
            proceedWorldBoss2.gameObject.SetActive(true);

            proceedEndless.gameObject.SetActive(false);
            proceedAdv.gameObject.SetActive(false);
            proceedWorldBoss1.gameObject.SetActive(false);

            if(GameMechanic.currentHunger <= 25){
                warningText1.text = "Hunger";
                warningText2.text = "ATK";
            }
            if(GameMechanic.currentFun <= 25){
                warningText1.text = "Fun";
                warningText2.text = "CRIT";
            }
            if(GameMechanic.currentStamina <= 25){
                warningText1.text = "Energy";
                warningText2.text = "SPD";
            }
            if(GameMechanic.currentHunger <= 25 && GameMechanic.currentFun <= 25){
                warningText1.text = "Hunger & Fun";
                warningText2.text = "ATK & CRIT";
            }
            if(GameMechanic.currentHunger <= 25 && GameMechanic.currentStamina <= 25){
                warningText1.text = "Hunger & Energy";
                warningText2.text = "ATK & SPD";
            }
            if(GameMechanic.currentFun <= 25 && GameMechanic.currentStamina <= 25){
                warningText1.text = "Fun & Energy";
                warningText2.text = "CRIT & SPD";
            }
            if(GameMechanic.currentHunger <= 25 && GameMechanic.currentFun <= 25 && GameMechanic.currentStamina <= 25){
                warningText1.text = "Hunger, Fun & Energy";
                warningText2.text = "ATK, CRIT & SPD";
            }
        }else{
            SceneManager.LoadScene("WorldBossScene", LoadSceneMode.Single);
            BossProfile.BossLevel = 2;
        }
    }

    public void GoWorldBoss3()
    {
        // Warning before go
        if(GameMechanic.currentHunger <= 25 || GameMechanic.currentFun <= 25 || GameMechanic.currentStamina <= 25){
            WarningWindow.gameObject.SetActive(true);

            // Button
            proceedWorldBoss3.gameObject.SetActive(true);

            proceedEndless.gameObject.SetActive(false);
            proceedAdv.gameObject.SetActive(false);
            proceedWorldBoss1.gameObject.SetActive(false);
            proceedWorldBoss2.gameObject.SetActive(false);

            if(GameMechanic.currentHunger <= 25){
                warningText1.text = "Hunger";
                warningText2.text = "ATK";
            }
            if(GameMechanic.currentFun <= 25){
                warningText1.text = "Fun";
                warningText2.text = "CRIT";
            }
            if(GameMechanic.currentStamina <= 25){
                warningText1.text = "Energy";
                warningText2.text = "SPD";
            }
            if(GameMechanic.currentHunger <= 25 && GameMechanic.currentFun <= 25){
                warningText1.text = "Hunger & Fun";
                warningText2.text = "ATK & CRIT";
            }
            if(GameMechanic.currentHunger <= 25 && GameMechanic.currentStamina <= 25){
                warningText1.text = "Hunger & Energy";
                warningText2.text = "ATK & SPD";
            }
            if(GameMechanic.currentFun <= 25 && GameMechanic.currentStamina <= 25){
                warningText1.text = "Fun & Energy";
                warningText2.text = "CRIT & SPD";
            }
            if(GameMechanic.currentHunger <= 25 && GameMechanic.currentFun <= 25 && GameMechanic.currentStamina <= 25){
                warningText1.text = "Hunger, Fun & Energy";
                warningText2.text = "ATK, CRIT & SPD";
            }
        }else{
            SceneManager.LoadScene("WorldBossScene", LoadSceneMode.Single);
            BossProfile.BossLevel = 3;
        }
    }

    public void proceedAdventureMode()
    {
        PlayerProfile.NerfStat();
        SceneManager.LoadScene("TatakaeScene", LoadSceneMode.Single);
    }
    public void proceedEndlessMode()
    {
        PlayerProfile.NerfStat();
        SceneManager.LoadScene("EndlessScene", LoadSceneMode.Single);
    }
    public void proceedWorldBossMode1()
    {
        PlayerProfile.NerfStat();
        SceneManager.LoadScene("WorldBossScene", LoadSceneMode.Single);
        BossProfile.BossLevel = 1;
    }
    public void proceedWorldBossMode2()
    {
        PlayerProfile.NerfStat();
        SceneManager.LoadScene("WorldBossScene", LoadSceneMode.Single);
        BossProfile.BossLevel = 2;
    }
    public void proceedWorldBossMode3()
    {
        PlayerProfile.NerfStat();
        SceneManager.LoadScene("WorldBossScene", LoadSceneMode.Single);
        BossProfile.BossLevel = 3;
    }
}
