using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Diary : MonoBehaviour
{
    public GameObject diaryUI;
    public bool usingDiary;
    public PlayerCamera playercam;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            usingDiary = !usingDiary;
        }

        if (usingDiary)
        {
            DiaryOpen();
            Cursor.visible = true;

            playercam.enabled = false;
        }
        else
        {
            DiaryClosed();
            Cursor.visible = false;
            playercam.enabled = true;
        }
    }

    void DiaryOpen()
    {
        Cursor.lockState = CursorLockMode.None;
        diaryUI.SetActive(true);
    }

    void DiaryClosed()
    {
        Cursor.lockState = CursorLockMode.Locked;
        diaryUI.SetActive(false);
    }
}
