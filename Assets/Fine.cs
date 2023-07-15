using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fine : MonoBehaviour
{

    public static bool GameIsOaused = false; 
    public GameObject FineMenuUI;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Resume(){
FineMenuUI.SetActive(false);
Time.timeScale =1f;
GameIsOaused = false;
    }

    public void Pause(){
FineMenuUI.SetActive(true);
Time.timeScale =0f;
GameIsOaused = true;
    }

    public PlayFabManager playfabManager;
    private AudioSource FineSuono;

    private bool levelCompleted = false;
    // Start is called before the first frame update
    private void Start()
    {
        FineSuono = GetComponent<AudioSource>();

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
if(collision.gameObject.name=="T Idle" && !levelCompleted){
    FineSuono.Play();
    levelCompleted=true;
    Invoke("CompleteLevel",2f);
}
    }

    private void CompleteLevel()
    {
        Pause();
//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);

    }

    public void ProssimoLivello(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
        Resume();
    }

    public void Quit(){
        SceneManager.LoadScene("Start Screen");
        Resume();
    }

}
