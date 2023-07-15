using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Livello2Button : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

public void OpenScene2(){
    SceneManager.LoadScene("Level 2");
}
}

