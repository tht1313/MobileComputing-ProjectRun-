using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{

    [SerializeField] private AudioSource AttaccoNemicoSuono;
    [SerializeField] private float attackCooldown;
    [SerializeField] private int damage;

    [SerializeField] private LayerMask playerLayer;

   [SerializeField]  private BoxCollider2D boxCollider;

   [SerializeField] private float range;

   [SerializeField] private float colliderDistance;

   public Animator anim;

   private EnemyPatrol enemyPatrol;

   private VitaPlayer playerHealth; 


    private float cooldownTimer = Mathf.Infinity;

    private void Awake(){
        anim = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<EnemyPatrol>();
    }

    // Update is called once per frame
    private void Update()
    {

        cooldownTimer = cooldownTimer + Time.deltaTime;

        //Attacca solo quando vedi il player
        if(PlayerInSight()){

            if(cooldownTimer >= attackCooldown){
            //Attacco
            cooldownTimer = 0;
            anim.SetTrigger("Attacco1");
            AttaccoNemicoSuono.Play();

        }

        }

        if(enemyPatrol != null){
            enemyPatrol.enabled = !PlayerInSight();
        }

        
    }

    private bool PlayerInSight(){
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range *  transform.localScale.x * colliderDistance,new Vector3 (boxCollider.bounds.size.x * range , boxCollider.bounds.size.y , boxCollider.bounds.size.z),0,Vector2.left , 0 , playerLayer);
        
if(hit.collider!=null){
    playerHealth = hit.transform.GetComponent<VitaPlayer>();
}

        return hit.collider!=null;
    }

    private void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range *  transform.localScale.x * colliderDistance, new Vector3 (boxCollider.bounds.size.x*range , boxCollider.bounds.size.y , boxCollider.bounds.size.z));
    }

    private void DamagePlayer(){
        if(PlayerInSight()){
            //Danno alla vita del player
            playerHealth.TakeDamage(damage); 

        }
    }
}
