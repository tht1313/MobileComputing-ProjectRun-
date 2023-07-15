using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VitaPlayer : MonoBehaviour
{

    [SerializeField] private AudioSource MorteSuono;
    [SerializeField] private AudioSource DannoSuono;

    public int health;
    public int maxHealth=10;

    public Animator animator;

    public Rigidbody2D myRigidBody;

    public Protagonista protagonista;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        animator = GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    private void Morte(){
animator.SetTrigger("Morte");
myRigidBody.bodyType = RigidbodyType2D.Static;
}

private void Restart(){
SceneManager.LoadScene(SceneManager.GetActiveScene().name);
}

    public void TakeDamage(int ammount){


        health -= ammount;
        DannoSuono.Play();
        if(health<= 0){

            Morte();
            MorteSuono.Play();
            

        }

    }

}
