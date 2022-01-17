using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Memory : MonoBehaviour
{

    public Examine examine;
    public GameObject memoryButton;
    public PlayerMovement player;
    public GameObject memoryEffect;
    public Animator anim;
    void Update()
    {
        anim.GetComponent<Animator>();

        if(Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(MemoryAdded());
        }
    }

    IEnumerator MemoryAdded()
    {
        yield return new WaitForSeconds(0.2f);
        anim.Play("MemoryUpdate");
        memoryButton.SetActive(true);
        Instantiate(memoryEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        examine.GetComponent<Examine>().onExamine = false;
        player.enabled = true;
      
        
        
      
        
    }
}
