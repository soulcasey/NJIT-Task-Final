using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public TrafficController Traffic;
    public Text Safe;
    public GameObject Hit;

    float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -10f)
        {
            SceneManager.LoadScene("Stage");
        }
        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * speed, 0, Input.GetAxis("Vertical") * Time.deltaTime * speed);
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Road")
        {
            Safe.text = "Not Safe! (On road)";
        }
        if(collision.gameObject.tag == "Cross1" && Traffic.GreenOn == false)
        {
            Safe.text = "Safe (Green light)";
        }
        if (collision.gameObject.tag == "Cross1" && Traffic.GreenOn == true)
        {
            Safe.text = "Not Safe! (Red light)";
        }

        if (collision.gameObject.tag == "Cross2" && Traffic.GreenOn == true)
        {
            Safe.text = "Safe (Green light)";
        }

        if (collision.gameObject.tag == "Cross2" && Traffic.GreenOn == false)
        {
            Safe.text = "Not Safe! (Red light)";
        }

    }

    private void OnTriggerExit(Collider collision)
    {
        Safe.text = "";
    }

}
