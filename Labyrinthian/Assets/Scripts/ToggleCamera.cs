using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleCamera : MonoBehaviour
{
    public Animator anim;
    public bool toggle;
    private int status;

    void Start()
    {
        anim = GetComponent<Animator>();
        status = 0;
        
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ToggleView();
        }
    
       
    }
    
    void ToggleView()
    {
        if(status == 0)
        {
            FirstPerson();
        }
        else if(status == 2)
        {
            TopDown();
        }
    }
    void TopDown()
    {
        status = 0;
        anim.Play("FirstPerson");
    }

    void FirstPerson()
    {
        status = 2;
        anim.Play("TopDown");
    }


}
