using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static AllNotation;

public class EndlessDamageText : MonoBehaviour
{
    public Text damageText;

    public GameObject canvas;
    public int x,y;
    public float Temporary_float;

    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;

        canvas = GameObject.Find("Text Damage Canvas");
        transform.SetParent(canvas.transform, false);

        x = Random.Range(-150, 151);
        y = Random.Range(50, 151);

        transform.localPosition = new Vector2(x, y);

        if(EndlessMode.CritText){
            damageText.color = Color.red;
        }
        else{
            damageText.color = Color.yellow;
        }
        
        Temporary_float = EndlessMode.TotalDamagePlayer;

        Convert(Temporary_float);
        damageText.text = AllNotation.AfterNotation;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= 1f){
            Destroy(this.gameObject);
        }

        transform.position = new Vector2(transform.position.x, transform.position.y + Time.deltaTime * 3);
    }
}
