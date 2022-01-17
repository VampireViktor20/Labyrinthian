using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public LayerMask interactMask = 8;
    void Start()
    {
        
    }


    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 2, interactMask))
        {
            Debug.Log(hit.collider.name);
        }
    }
}
