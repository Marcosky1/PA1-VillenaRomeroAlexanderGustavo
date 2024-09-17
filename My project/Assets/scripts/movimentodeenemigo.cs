using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimentodeenemigo : MonoBehaviour
{
    private Rigidbody rigibody;
    public int speed;
    void Start()
    {
        rigibody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > -22) { }
        speed = speed + 1;
        if(17 > transform.position.z) {
            speed = speed - 1;
        }
        transform.position = Vector3.MoveTowards(transform.position, transform.position, speed * Time.deltaTime);
    }
}
