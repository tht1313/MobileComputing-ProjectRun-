using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


public class CollettoreOggetti : MonoBehaviour
{

    private int NumeroAnime = 0;

[SerializeField] private Text ConteggioAnime;

[SerializeField] private AudioSource CollettoreSuono;
    public void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Fiamma")){
            CollettoreSuono.Play();
            Destroy(collision.gameObject);
            NumeroAnime++;
            ConteggioAnime.text = "Anime = " + NumeroAnime;
            Debug.Log("Numero Anime =" +NumeroAnime);
        }
    }

}