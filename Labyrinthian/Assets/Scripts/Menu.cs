using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public GameObject controlsPanel;
    public GameObject closeButton;

    public void Start()
    {
        Cursor.visible = true;
    }

    public void Play()
    {
        SceneManager.LoadScene("Maze");
    }

    public void Controls()
    {
        controlsPanel.SetActive(true);
    }

    public void ClosePanel()
    {
        controlsPanel.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
