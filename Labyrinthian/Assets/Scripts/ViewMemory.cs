using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewMemory : MonoBehaviour
{

    public GameObject memoryNote;
    

    // Update is called once per frame
 

    public void OpenMemory()
    {
        memoryNote.SetActive(true);
    }

    public void CloseMemory()
    {
        memoryNote.SetActive(false);
    }
}
