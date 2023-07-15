using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsOaused = false; 
    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Resume(){
pauseMenuUI.SetActive(false);
Time.timeScale =1f;
GameIsOaused = false;
    }

    public void Pause(){
pauseMenuUI.SetActive(true);
Time.timeScale =0f;
GameIsOaused = true;
    }

    
public void Uscire(){
    SceneManager.LoadScene("Start Screen");
    Resume();
}
}
