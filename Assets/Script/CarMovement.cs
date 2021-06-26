using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public GameObject TrafficLight;

    public Rigidbody rb;
    public float StartPosition;
    public float StopPosition; 
    public float EndPosition;

    public float speed;

    public bool Sensor;

    public bool Horizontal;
    private bool Go;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Sensor = false;
        if (Horizontal)
        {
            transform.position = new Vector3(StartPosition, transform.position.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, StartPosition);
        }
        Go = false;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float direction;

        if(Horizontal)
        {
            direction = transform.position.x;
        }
        else
        {
            direction = transform.position.z;
        }

        TrafficController traffic = TrafficLight.GetComponent<TrafficController>();

        if(Mathf.Abs(direction) > Mathf.Abs(StopPosition) || Go)
        {
            Drive();
        }

        if(Mathf.Abs(direction) <= Mathf.Abs(StopPosition))
        {
            if(traffic.GreenOn == true)
            {
                Go = true;
            }
        }

        if (Mathf.Abs(direction - EndPosition) < 0.5f)
        {
            if (Horizontal)
            {
                transform.position = new Vector3(StartPosition, transform.position.y, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, StartPosition);
            }
            Go = false;
        }
    }


    private void Drive()
    {
        if (Sensor == false)
        {
            transform.GetChild(1).Rotate(2f * speed, 0, 0);
            transform.GetChild(2).Rotate(2f * speed, 0, 0);
            transform.GetChild(3).Rotate(2f * speed, 0, 0);
            transform.GetChild(4).Rotate(2f * speed, 0, 0);
            rb.velocity = transform.forward * speed;
        }
    }

}
