using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleCamera : MonoBehaviour
{
    public Animator anim;
    public bool toggle;
    public int status;

    public float endTime;
    public float currentTime;
    public bool startAnim;


    void Start()
    {

        anim = GetComponent<Animator>();
        status = 0;
        
        
    }


    void Update()
    {
        if(startAnim)
        {
            currentTime += Time.deltaTime;
            if(currentTime >= endTime)
            {
                toggle = !toggle;
                startAnim = false;
                currentTime = 0;
                GetComponent<Animator>().enabled = toggle;
            }
        }

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

        startAnim = true;
        status = 0;
        anim.Play("FirstPerson");
       
    }

    void FirstPerson()
    {
        startAnim = true;
        status = 2;
        anim.Play("TopDown");
        
    }


}
