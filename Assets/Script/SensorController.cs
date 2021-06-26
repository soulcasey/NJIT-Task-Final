using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorController : MonoBehaviour
{
    public CarMovement Car;
    // Start is called before the first frame update
    void Start()
    {

        Debug.Log("hihi");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Car")
        {
            Car.Sensor = true;
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Car")
        {
            Car.Sensor = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        Car.Sensor = false;
    }

}
