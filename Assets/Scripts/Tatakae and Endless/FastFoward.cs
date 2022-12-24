using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastFoward : MonoBehaviour
{
    public static bool FastTime;

    // Start is called before the first frame update
    void Start()
    {
        FastTime = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NormalSpeed(){
        Time.timeScale = 1f;
        FastTime = false;
    }

    public void FastSpeed(){
        Time.timeScale = 2f;
        FastTime = true;
    }
}
