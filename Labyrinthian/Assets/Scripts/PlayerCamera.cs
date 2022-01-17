using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public float mouseSensitivity = 100f;

    public Transform playerBody;
    readonly int camSmooth = 4;
    public Examine examine;
    public float xRotation = 90f;
   


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    void Update()
    {
        if (examine.GetComponent<Examine>().onExamine == false)
        {


            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime * camSmooth;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime * camSmooth;

            xRotation -= mouseY;

            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }
}
