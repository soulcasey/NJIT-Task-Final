using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficController : MonoBehaviour
{

    public GameObject Red;
    public GameObject Yellow;
    public GameObject Green;

    public bool RedOn;
    public bool GreenOn;

    public bool Horizontal;

    private float LightChangeTime;
    private float ChangeDelay = 10f;

    void Start()
    {

        if (Horizontal)
        {
            RedLight();
        }
        else
        {
            GreenLight();
        }
        LightChangeTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= LightChangeTime + ChangeDelay)
        {
            YellowLight();
            if(Time.time >= LightChangeTime + ChangeDelay + 3)
            {
                if(RedOn == true)
                {
                    GreenLight();
                }
                else if (GreenOn == true)
                {
                    RedLight();
                }
                LightChangeTime = Time.time;
            }
        }
    }

    private void RedLight()
    {
        gameObject.GetComponent<AudioSource>().Play();
        RedOn = true;
        GreenOn = false;
        Red.GetComponent<Renderer>().material.color = Color.red;
        Yellow.GetComponent<Renderer>().material.color = Color.black;
        Green.GetComponent<Renderer>().material.color = Color.black;
    }

    private void YellowLight()
    {
        Red.GetComponent<Renderer>().material.color = Color.black;
        Yellow.GetComponent<Renderer>().material.color = Color.yellow;
        Green.GetComponent<Renderer>().material.color = Color.black;
    }

    private void GreenLight()
    {
        gameObject.GetComponent<AudioSource>().Play();
        RedOn = false;
        GreenOn = true;
        Red.GetComponent<Renderer>().material.color = Color.black;
        Yellow.GetComponent<Renderer>().material.color = Color.black;
        Green.GetComponent<Renderer>().material.color = Color.green;
    }
}
