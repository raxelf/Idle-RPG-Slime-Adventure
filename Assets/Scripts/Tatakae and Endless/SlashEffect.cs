using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlashEffect : MonoBehaviour
{
    public GameObject Slash;

    public GameObject canvas;
    public int x,y;

    public float r;
    public float ry;

    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;

        canvas = GameObject.Find("Slash Effect Canvas");
        transform.SetParent(canvas.transform, false);

        x = Random.Range(-180, 180);
        y = Random.Range(50, 340);
        r = Random.Range(0, 2);

        transform.localPosition = new Vector2(x, y);

        if(TawuranSimulator.CritText){
            Slash.GetComponent<Image>().color = Color.red;
        }
        else{
            Slash.GetComponent<Image>().color = Color.white;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= .4f){
            Destroy(this.gameObject);
        }

        if(r == 0){
            ry = 0;
        }else{
            ry = 180;
        }

        transform.position = new Vector2(transform.position.x, transform.position.y);
        transform.rotation = Quaternion.Euler(0, ry, 0);
    }
}
