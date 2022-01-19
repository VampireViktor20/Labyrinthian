using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Diary : MonoBehaviour
{
    public GameObject diaryUI;
    public bool usingDiary;
    public PlayerCamera playercam;
    public PlayerMovement player;

    void Start()
    {
        diaryUI.SetActive(false);
    }

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
            player.enabled = false;
        }
        else
        {
            DiaryClosed();
            Cursor.visible = false;
            playercam.enabled = true;
            player.enabled = true;
        }
    }

    void DiaryOpen()
    {
        Cursor.lockState = CursorLockMode.Confined;
        diaryUI.SetActive(true);
    }

    void DiaryClosed()
    {
        Cursor.lockState = CursorLockMode.Locked;
        diaryUI.SetActive(false);

    }
}
