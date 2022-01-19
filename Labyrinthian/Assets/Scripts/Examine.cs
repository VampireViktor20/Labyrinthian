using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Examine : MonoBehaviour
{
    public float distance;
    public Transform playerSocket;
    public Memory memory;
    public GameObject interactIcon;
    public GameObject MemoryText;

    Vector3 originalPos;
    public  bool onExamine = false;
    GameObject examined;
    
   
    public PlayerMovement player;

    public void Update()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;

        if (Physics.Raycast(transform.position, fwd, out hit, distance)) 
        {
            if(hit.transform.tag == "Memory" && !onExamine)
            {
                interactIcon.SetActive(true);
                if(Input.GetKeyDown(KeyCode.Mouse0))
                {
                    MemoryText.SetActive(true);
                    examined = hit.transform.gameObject;
                    originalPos = hit.transform.position;
                    memory = hit.transform.gameObject.GetComponent<Memory>();
                    onExamine = true;
           

                    StartCoroutine(pickupItem());
                }
            }
            else
            {
                interactIcon.SetActive(false);
            }
        }

        if(onExamine)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(memory.MemoryAdded());
                MemoryText.SetActive(false);
                memory = null;
            }
            playerSocket.Rotate(new Vector3(Input.GetAxis("Mouse Y"), -Input.GetAxis("Mouse X"), 0) * Time.deltaTime * 350f);
            examined.transform.position = Vector3.Lerp(examined.transform.position, playerSocket.position, 0.2f);
            

        }
        else if(examined != null)
        {
            examined.transform.SetParent(null);
            examined.transform.position = Vector3.Lerp(examined.transform.position, originalPos, 0.2f);

        }

        if(Input.GetKeyDown(KeyCode.Mouse1) && onExamine)
        {
            MemoryText.SetActive(false);
            StartCoroutine(dropItem());
            onExamine = false;
        }


        IEnumerator pickupItem()
        {
            player.enabled = false;
            yield return new WaitForSeconds(0.2f);
            examined.transform.SetParent(playerSocket);

        }

        IEnumerator dropItem()
        {
            examined.transform.rotation = Quaternion.identity;
            yield return new WaitForSeconds(0.2f);
            player.enabled = true;
        }
           
    }
   



}
