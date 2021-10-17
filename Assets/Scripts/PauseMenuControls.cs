using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuControls : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isPaused;
    public GameObject PauseMenuCanvas;
   

    // Update is called once per frame
    void Update()
    {

        if (isPaused)
        {
            PauseMenuCanvas.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            PauseMenuCanvas.SetActive(false);  
            Time.timeScale = 1f;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
   
            isPaused = !isPaused;
        }
    }

    public void Continue()
    {
        isPaused = false;
    }

    public void Quit()
    {
        
        SceneManager.LoadScene("Menu");
    }
    
}
