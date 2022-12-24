using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinScript : MonoBehaviour
{
    public Image Player;
    public Image[] SkinList;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Player.sprite = SkinList[PlayerProfile.SkinID].sprite;
    }
}
