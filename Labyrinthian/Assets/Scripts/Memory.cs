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

    void Start()
    {
        anim.GetComponent<Animator>();

        
    }

    public IEnumerator MemoryAdded()
    {
        
        memoryButton.SetActive(true);
        Instantiate(memoryEffect, transform.position, Quaternion.identity);
        examine.GetComponent<Examine>().onExamine = false;
        player.enabled = true;
        gameObject.SetActive(false);
        anim.SetBool("MemoryUpdate", true);
        yield return new WaitForSeconds(3f);
        anim.SetBool("MemoryUpdate", false);
        Destroy(gameObject);





    }
}
