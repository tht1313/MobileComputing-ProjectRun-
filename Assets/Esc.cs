using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Esc : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

public void Uscire(){
    SceneManager.LoadScene("Start Screen");
}
}
