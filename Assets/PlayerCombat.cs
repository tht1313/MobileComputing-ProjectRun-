using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    [SerializeField] private AudioSource AttaccoSuono;
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask Nemici;
    public int attackDamage = 2;

    public float attackRate = 2f;
    float nextAttackTime = 0f;
    // Update is called once per frame
    void Update()
    {

    }

    public void AttaccoLento(){

        
                if(Time.time >= nextAttackTime){


            //Script Attacco
            Attack();
            nextAttackTime = Time.time +1f/attackRate;


        }

    }

        public void Attack(){

            //Animazione
            animator.SetTrigger("Attacco");
            //Range al Nemico

            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position , attackRange , Nemici);

            //Danno al Nemico

            foreach(Collider2D enemy in hitEnemies){
                enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
            }

            //Suono Attacco
            AttaccoSuono.Play();

        }

        private void OnDrawGizmosSelected(){
            Gizmos.DrawWireSphere(attackPoint.position , attackRange);
        }
    
}
