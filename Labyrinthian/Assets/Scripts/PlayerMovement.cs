using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    public float speed;
    public bool isRunning;
    public GameObject compass;
    public bool usingCompass;
    

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetKey(KeyCode.LeftShift))
        {
            isRunning = !isRunning;
            Run();
        }

        if(Input.GetKeyDown(KeyCode.U))
        {
            usingCompass = !usingCompass;
            Compass();
        }

    }

    void Run()
    {
        if(isRunning)
        {
            speed = 9f;
        }
        else 
        {
            speed = 6f;
        }
    }

    public void Compass()
    {
        if(usingCompass)
        {
            compass.SetActive(true);
        }
        
        if(!usingCompass)
        {
            compass.SetActive(false);
        }
    }
    
}
