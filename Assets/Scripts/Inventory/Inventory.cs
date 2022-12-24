using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    // Inventory
    [SerializeField]
    public GameObject[] Slot;
    public Text[] foodHaveText;
    // Item Amount
    public int[] foodHave;

    // Sound
    public AudioClip eatingSound;
    public AudioSource eatingSource;

    public AudioSource boxDropSource;
    public AudioClip boxDropSound;

    public AudioSource boxShakeSource;
    public AudioClip boxShakeSound;

    public AudioSource boxExplodeSource;
    public AudioClip boxExplodeSound;

    // Gacha
    [Range(0.0f,100)]
    public float commonChance;
    [Range(0.0f,100)]
    public float uncommonChance;
    [Range(0.0f,100)]
    public float rareChance;

    // Common
    public GameObject common;
    public GameObject commonWindows;

    [SerializeField]
    public GameObject[] commonFood;
    public int[] commonFoodGet;
    public Text[] commonFoodText;

    // Uncommon
    public GameObject uncommon;
    public GameObject uncommonWindows;

    [SerializeField]
    public GameObject[] uncommonFood;
    public int[] uncommonFoodGet;
    public Text[] uncommonFoodText;

    // Rare
    public GameObject rare;
    public GameObject rareWindows;

    [SerializeField]
    public GameObject[] rareFood;
    public int[] rareFoodGet;
    public Text[] rareFoodText;

    // X10 Gacha
    public GameObject x10Gacha;
    public GameObject x10Windows;
    [SerializeField]
    public GameObject[] x10Food;
    public int[] getX10Food;
    public int[] getX10FoodTotal;
    public Text[] getX10FoodText;

    // Not Enough Coin
    public GameObject NotEnough;


    void Start() {
        // foodHave 1-20 = 0
        for(int i = 0; i <= 19; i++){
            foodHave[i] = 0;
        }

        foodHave[0] = 5;
        foodHave[4] = 5;
    }

    void Update() 
    {
        for(int i = 0; i <= 19; i++){
            // foodHave Text
            foodHaveText[i].text = "x" + foodHave[i];

            // not showing item , if item = 0
            // make sure item doesnt go below 0
            if(foodHave[i] <= 0){
                foodHave[i] = 0;
                Slot[i].gameObject.SetActive(false);
            }else{
                Slot[i].gameObject.SetActive(true);
            }
        }

        // Common Gacha
        for(int i = 0; i <= 4; i++){
            // Common Get Text
            commonFoodText[i].text = "x" + commonFoodGet[i];

            if(commonFoodGet[i] <= 0){
                commonFoodGet[i] = 0;
                commonFood[i].gameObject.SetActive(false);
            }else{
                commonFood[i].gameObject.SetActive(true);
            }
        }
        // unCommon Gacha
        for(int i = 0; i <= 9; i++){
            // unCommon Get Text
            uncommonFoodText[i].text = "x" + uncommonFoodGet[i];

            if(uncommonFoodGet[i] <= 0){
                uncommonFoodGet[i] = 0;
                uncommonFood[i].gameObject.SetActive(false);
            }else{
                uncommonFood[i].gameObject.SetActive(true);
            }
        }
        // Rare Gacha
        for(int i = 0; i <= 9; i++){
            // Rare Get Text
            rareFoodText[i].text = "x" + rareFoodGet[i];

            if(rareFoodGet[i] <= 0){
                rareFoodGet[i] = 0;
                rareFood[i].gameObject.SetActive(false);
            }else{
                rareFood[i].gameObject.SetActive(true);
            }
        }

        // x10 Gacha
        for(int i = 0; i <= 19; i++){
            // X10 Food Get Text
            getX10FoodText[i].text = "x" + getX10FoodTotal[i];

            if(getX10FoodTotal[i] <= 0){
                getX10FoodTotal[i] = 0;
                x10Food[i].gameObject.SetActive(false);
            }else{
                x10Food[i].gameObject.SetActive(true);
            }
        }
    }

    public void useItem0()
    {
        foodHave[0] -= 1;
        GameMechanic.currentHunger += 5;
        GameMechanic.currentFun += 5;
        GameMechanic.currentStamina += 3;
        eatingSource.PlayOneShot(eatingSound);
    }

    public void useItem1()
    {
        foodHave[1] -= 1;
        GameMechanic.currentHunger += 5;
        GameMechanic.currentFun += 5;
        GameMechanic.currentStamina += 3;
        eatingSource.PlayOneShot(eatingSound);
    }

    public void useItem2()
    {
        foodHave[2] -= 1;
        GameMechanic.currentHunger += 10;
        GameMechanic.currentFun += 5;
        GameMechanic.currentStamina += 3;
        eatingSource.PlayOneShot(eatingSound);

    }

    public void useItem3()
    {
        foodHave[3] -= 1;
        GameMechanic.currentHunger += 5;
        GameMechanic.currentStamina += 1;
        eatingSource.PlayOneShot(eatingSound);
    }

    public void useItem4()
    {
        foodHave[4] -= 1;
        GameMechanic.currentHunger += 10;
        GameMechanic.currentFun += 10;
        GameMechanic.currentStamina += 5;
        eatingSource.PlayOneShot(eatingSound);

    }

    public void useItem5()
    {
        foodHave[5] -= 1;
        GameMechanic.currentHunger += 15;
        GameMechanic.currentFun += 10;
        eatingSource.PlayOneShot(eatingSound);
    }
    
    public void useItem6()
    {
        foodHave[6] -= 1;
        GameMechanic.currentHunger += 15;
        GameMechanic.currentFun += 15;
        GameMechanic.currentStamina += 5;
        eatingSource.PlayOneShot(eatingSound);
    }

    public void useItem7()
    {
        foodHave[7] -= 1;
        GameMechanic.currentHunger += 15;
        GameMechanic.currentFun += 5;
        eatingSource.PlayOneShot(eatingSound);
    }

    public void useItem8()
    {
        foodHave[8] -= 1;
        GameMechanic.currentHunger += 20;
        GameMechanic.currentFun += 10;
        eatingSource.PlayOneShot(eatingSound);
    }

    public void useItem9()
    {
        foodHave[9] -= 1;
        GameMechanic.currentHunger += 15;
        GameMechanic.currentFun += 5;
        eatingSource.PlayOneShot(eatingSound);
    }

    public void useItem10()
    {
        foodHave[10] -= 1;
        GameMechanic.currentHunger += 15;
        GameMechanic.currentFun += 10;
        GameMechanic.currentStamina += 5;
        eatingSource.PlayOneShot(eatingSound);
    }

    public void useItem11()
    {
        foodHave[11] -= 1;
        GameMechanic.currentHunger += 10;
        GameMechanic.currentFun += 5;
        eatingSource.PlayOneShot(eatingSound);

    }

    public void useItem12()
    {
        foodHave[12] -= 1;
        GameMechanic.currentHunger += 20;
        GameMechanic.currentFun += 15;
        GameMechanic.currentStamina += 10;
        eatingSource.PlayOneShot(eatingSound);
    }

    public void useItem13()
    {
        foodHave[13] -= 1;
        GameMechanic.currentHunger += 20;
        GameMechanic.currentFun += 10;
        GameMechanic.currentStamina += 10;
        eatingSource.PlayOneShot(eatingSound);
    }

    public void useItem14()
    {
        foodHave[14] -= 1;
        GameMechanic.currentHunger += 15;
        GameMechanic.currentFun += 10;
        GameMechanic.currentStamina += 3;
        eatingSource.PlayOneShot(eatingSound);
    }

    public void useItem15()
    {
        foodHave[15] -= 1;
        GameMechanic.currentHunger += 15;
        GameMechanic.currentFun += 10;
        GameMechanic.currentStamina += 5;
        eatingSource.PlayOneShot(eatingSound);
    }

    public void useItem16()
    {
        foodHave[16] -= 1;
        GameMechanic.currentHunger += 20;
        GameMechanic.currentFun += 5;
        eatingSource.PlayOneShot(eatingSound);
    }

    public void useItem17()
    {
        foodHave[17] -= 1;
        GameMechanic.currentHunger += 30;
        GameMechanic.currentFun += 15;
        GameMechanic.currentStamina += 5;
        eatingSource.PlayOneShot(eatingSound);
    }

    public void useItem18()
    {
        foodHave[18] -= 1;
        GameMechanic.currentHunger += 30;
        GameMechanic.currentFun += 15;
        eatingSource.PlayOneShot(eatingSound);
    }

    public void useItem19()
    {
        foodHave[19] -= 1;
        GameMechanic.currentHunger += 20;
        GameMechanic.currentFun += 20;
        eatingSource.PlayOneShot(eatingSound);
    }

    // Gacha 
    public void FoodGacorX1()
    {
        if(GameMechanic.Coin >= 999){
            GameMechanic.Coin -= 999;

            float r = Random.Range(0.0f, 101.1f);

            if(r >= commonChance){
                getCommon();
            }
            else if(r >= uncommonChance){
                getUncommon();
            }
            else if(r >= rareChance){
                getRare();
            }
        }else{
            if(!NotEnough.activeSelf){
                NotEnough.gameObject.SetActive(true);
                StartCoroutine(HideNotEnough());
            }else{
                return;
            }
        }

        
    }

    public void FoodGacorX10()
    {
        if(GameMechanic.Coin >= 9999){
            GameMechanic.Coin -= 9999;
            x10Gacha.gameObject.SetActive(true);
            GachaX10();
            StartCoroutine(Waitx10Gacha());
        }else{
            if(!NotEnough.activeSelf){
                NotEnough.gameObject.SetActive(true);
                StartCoroutine(HideNotEnough());
            }else{
                return;
            }
        }        
    }

    IEnumerator HideNotEnough()
    {
        
        yield return new WaitForSeconds(3f);
        NotEnough.gameObject.SetActive(false);
    }

    void getCommon()
    {
        common.gameObject.SetActive(true);
        for(int i = 0; i <= 4; i++){
            commonFoodGet[i] = 0;
        }
        StartCoroutine(WaitCommonGacha());
    }

    void getUncommon()
    {
        uncommon.gameObject.SetActive(true);
        for(int i = 0; i <= 9; i++){
            uncommonFoodGet[i] = 0;
        }
        StartCoroutine(WaitUncommonGacha());   
    }

    void getRare()
    {
        rare.gameObject.SetActive(true);
        for(int i=0; i <= 4; i++){
            rareFoodGet[i] = 0;
        }
        StartCoroutine(WaitRareGacha());
    }

    void GachaX10()
    {
        // Reset Amount
        for(int x= 0; x<= 19; x++){
                getX10FoodTotal[x] = 0;
                getX10Food[x] = 0;
        }
        for(int i = 0;i <= 4;i++){
            commonFoodGet[i] = 0;
        }
        for(int i = 0; i <= 9; i++){
            uncommonFoodGet[i] = 0;
            rareFoodGet[i] = 0;
        }

        // Loop x10 Gacha
        for(int i = 0; i <= 9; i++){
            float r = Random.Range(0.0f, 101.1f);

            if(r >= commonChance){
                CommonGacha();
            }
            else if(r >= uncommonChance){
                UncommonGacha();
            }
            else if(r >= rareChance){
                RareGacha();
            }
        }
    }

    IEnumerator WaitCommonGacha()
    {
        yield return new WaitForSeconds(.37f);
        boxDropSource.Play();
        yield return new WaitForSeconds(.10f);
        boxShakeSource.PlayOneShot(boxShakeSound);
        yield return new WaitForSeconds(.80f);
        boxShakeSource.Stop();
        boxExplodeSource.PlayOneShot(boxExplodeSound);
        yield return new WaitForSeconds(.43f);
        commonWindows.gameObject.SetActive(true);
        CommonGacha();
    }
    IEnumerator WaitUncommonGacha()
    {
        yield return new WaitForSeconds(.37f);
        boxDropSource.Play();
        yield return new WaitForSeconds(.10f);
        boxShakeSource.PlayOneShot(boxShakeSound);
        yield return new WaitForSeconds(.80f);
        boxShakeSource.Stop();
        boxExplodeSource.PlayOneShot(boxExplodeSound);
        yield return new WaitForSeconds(.43f);
        uncommonWindows.gameObject.SetActive(true);
        UncommonGacha();
    }
    IEnumerator WaitRareGacha()
    {
        yield return new WaitForSeconds(.37f);
        boxDropSource.Play();
        yield return new WaitForSeconds(.10f);
        boxShakeSource.PlayOneShot(boxShakeSound);
        yield return new WaitForSeconds(.80f);
        boxShakeSource.Stop();
        boxExplodeSource.PlayOneShot(boxExplodeSound);
        yield return new WaitForSeconds(.43f);
        rareWindows.gameObject.SetActive(true);
        RareGacha();
    }

    IEnumerator Waitx10Gacha()
    {   
        for(int x= 0; x<= 19; x++){
                getX10FoodTotal[x] = getX10FoodTotal[x] + getX10Food[x];
        }
        yield return new WaitForSeconds(.30f);
        boxDropSource.PlayOneShot(boxDropSound);
        yield return new WaitForSeconds(.20f);
        boxDropSource.PlayOneShot(boxDropSound);
        yield return new WaitForSeconds(.30f);
        boxDropSource.PlayOneShot(boxDropSound);
        yield return new WaitForSeconds(.5f);
        x10Windows.gameObject.SetActive(true);
    }

    void CommonGacha()
    {
        int r0 = Random.Range(0,2);
        int r1 = Random.Range(0,2);
        int r2 = Random.Range(0,2);
        int r3 = Random.Range(0,2);
        int r4 = Random.Range(0,2);

        commonFoodGet[0] += r0;
        commonFoodGet[1] += r1;
        commonFoodGet[2] += r2;
        commonFoodGet[3] += r3;
        commonFoodGet[4] += r4;

        for(int i = 0;i <= 4;i++){
            foodHave[i] += commonFoodGet[i];
            getX10Food[i] += commonFoodGet[i];
        }
    }

    void UncommonGacha()
    {
        int r0 = Random.Range(0,2);
        int r1 = Random.Range(0,2);
        int r2 = Random.Range(0,2);
        int r3 = Random.Range(0,2);
        int r4 = Random.Range(0,2);
        int r5 = Random.Range(0,2);
        int r6 = Random.Range(0,2);
        int r7 = Random.Range(0,2);
        int r8 = Random.Range(0,2);
        int r9 = Random.Range(0,2);

        uncommonFoodGet[0] += r0;
        uncommonFoodGet[1] += r1;
        uncommonFoodGet[2] += r2;
        uncommonFoodGet[3] += r3;
        uncommonFoodGet[4] += r4;
        uncommonFoodGet[5] += r5;
        uncommonFoodGet[6] += r6;
        uncommonFoodGet[7] += r7;
        uncommonFoodGet[8] += r8;
        uncommonFoodGet[9] += r9;

        for(int i = 0;i <= 9;i++){
            foodHave[i] += uncommonFoodGet[i];
            getX10Food[i] += uncommonFoodGet[i];
        }
    }

    void RareGacha()
    {
        int r0 = Random.Range(0,2);
        int r1 = Random.Range(0,2);
        int r2 = Random.Range(0,2);
        int r3 = Random.Range(0,2);
        int r4 = Random.Range(0,2);
        int r5 = Random.Range(0,2);
        int r6 = Random.Range(0,2);
        int r7 = Random.Range(0,2);
        int r8 = Random.Range(0,2);
        int r9 = Random.Range(0,2);

        rareFoodGet[0] += r0;
        rareFoodGet[1] += r1;
        rareFoodGet[2] += r2;
        rareFoodGet[3] += r3;
        rareFoodGet[4] += r4;
        rareFoodGet[5] += r5;
        rareFoodGet[6] += r6;
        rareFoodGet[7] += r7;
        rareFoodGet[8] += r8;
        rareFoodGet[9] += r9;

        foodHave[10] += rareFoodGet[0];
        foodHave[11] += rareFoodGet[1];
        foodHave[12] += rareFoodGet[2];
        foodHave[13] += rareFoodGet[3];
        foodHave[14] += rareFoodGet[4];
        foodHave[15] += rareFoodGet[5];
        foodHave[16] += rareFoodGet[6];
        foodHave[17] += rareFoodGet[7];
        foodHave[18] += rareFoodGet[8];
        foodHave[19] += rareFoodGet[9];
        
        getX10Food[10] += rareFoodGet[0];
        getX10Food[11] += rareFoodGet[1];
        getX10Food[12] += rareFoodGet[2];
        getX10Food[13] += rareFoodGet[3];
        getX10Food[14] += rareFoodGet[4];
        getX10Food[15] += rareFoodGet[5];
        getX10Food[16] += rareFoodGet[6];
        getX10Food[17] += rareFoodGet[7];
        getX10Food[18] += rareFoodGet[8];
        getX10Food[19] += rareFoodGet[9];
    }
}
