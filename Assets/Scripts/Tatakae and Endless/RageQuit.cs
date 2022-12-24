using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RageQuit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RageQuitAsu()
    {
        SceneManager.LoadScene("gameScene", LoadSceneMode.Single);
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        if(FastFoward.FastTime){
            Time.timeScale = 2f;
        }
        else{
            Time.timeScale = 1f;
        }
    }
}
