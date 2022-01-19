using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{

    public GameObject endScene;
    public PlayerMovement player;
    public GameObject timer;
 

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag== "Player")
        {
            StartCoroutine(EndScene());
            
        }
    }

    public IEnumerator EndScene()
    {

        player.enabled = false;
        endScene.SetActive(true);
        timer.SetActive(false);
        yield return new WaitForSeconds(8f);
        SceneManager.LoadScene("MainMenu");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }
}


