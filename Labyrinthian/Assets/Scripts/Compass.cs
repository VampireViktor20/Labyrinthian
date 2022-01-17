using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour
{

    public Transform target;
    public Transform housing;
    public float speed = 1f;
    
    //public GameObject arrow;
 
    void Update()
    {

        Vector3 lookPos = target.position - transform.position;
        transform.up = Vector3.Slerp(transform.up, lookPos, Time.deltaTime * speed);

        //transform.rotation = Quaternion.Euler(0, -Input.compass.trueHeading, 0);
    }
}
