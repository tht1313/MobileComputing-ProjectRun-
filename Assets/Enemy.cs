using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy : MonoBehaviour{

    [SerializeField] private AudioSource MorteNemicoSuono;

public int maxHealth = 10;

public Animator animator;
int currentHealth;

public int damage=2;

public Rigidbody2D myRigidBody;

public VitaPlayer playerhealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth=maxHealth;
    }

    //Funzione che danneggia

    public void TakeDamage(int damage){
        currentHealth = currentHealth-damage;

        //Animazione Danno
        animator.SetTrigger("Hurt");

        if(currentHealth<=0){
            Die();
            MorteNemicoSuono.Play();

        }
    }

    void Die(){
        Debug.Log("Nemico Morto");
        animator.SetBool("IsDead",true);
          GetComponent<Collider2D>().enabled=false;
            GetComponentInParent<EnemyPatrol>().enabled=false;
            GetComponent<MeleeEnemy>().enabled=false;
        this.enabled=false;
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Protagonista"){

            playerhealth.TakeDamage(damage);

        }
    }
}
