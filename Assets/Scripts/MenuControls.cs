using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControls : MonoBehaviour
{
    public void NewGamePressed()
    {
        Debug.Log("New Game started");
        
        SceneManager.LoadScene("race_choose");
    }

    public void ExitPressed()
    {
        Debug.Log("Exit Game");
        Application.Quit();
    }
    
}
