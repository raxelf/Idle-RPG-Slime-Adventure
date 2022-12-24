using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reaction : MonoBehaviour
{
    public GameObject hungryEmoji;
    public GameObject hungryEmoji2;

    // Petting
    public bool isPetting;
    public bool needPetting;

    public GameObject needPetEmoji;
    public GameObject heartEmoji;
    public GameObject angryEmoji;
        // Timer
    public float currentTime = 300;
    public float maxTime = 300;

    void Update()
    {
        // Hungry Emoji
        if(isPetting == true || needPetting == true){
            hungryEmoji.gameObject.SetActive(false);
            hungryEmoji2.gameObject.SetActive(false);
        }else{
            if(GameMechanic.currentHunger > 25){
                hungryEmoji.gameObject.SetActive(true);
                hungryEmoji2.gameObject.SetActive(false);
            }
            if(GameMechanic.currentHunger < 25){
                hungryEmoji2.gameObject.SetActive(true);
                hungryEmoji.gameObject.SetActive(false);
            }
            if(GameMechanic.currentHunger >= 50){
                hungryEmoji.gameObject.SetActive(false);
                hungryEmoji2.gameObject.SetActive(false);
            }
        }

        // Petting
        currentTime -= 1f * Time.deltaTime;
        if(currentTime <= 0){
            needPetting = true;
            currentTime = 0;
            needPetEmoji.gameObject.SetActive(true);
        }else {
            needPetEmoji.gameObject.SetActive(false);
        }
    }

    public void Petting()
    {
        if(currentTime == 0){
            isPetting = true;
            needPetting = false;
            currentTime = maxTime;
            GameMechanic.currentFun += 65;
            heartEmoji.gameObject.SetActive(true);
            StartCoroutine(HeartEmojiErase());
        }else {
            isPetting = true;
            angryEmoji.gameObject.SetActive(true);
            StartCoroutine(AngryEmojiErase());
        }
    }

    IEnumerator HeartEmojiErase()
    {
        yield return new WaitForSeconds(3f);
        isPetting = false;
        heartEmoji.gameObject.SetActive(false);
    }

    IEnumerator AngryEmojiErase()
    {
        yield return new WaitForSeconds(3f);
        isPetting = false;
        angryEmoji.gameObject.SetActive(false);
    }
}
