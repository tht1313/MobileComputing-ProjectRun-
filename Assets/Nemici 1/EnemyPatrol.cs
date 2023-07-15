using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
[SerializeField] private Transform leftEdge;
[SerializeField] private Transform rightEdge;

[SerializeField] private Transform enemy;

[SerializeField] private float speed;

private Vector3 initScale;

private bool MovingLeft;

[SerializeField] private Animator anim;  

[SerializeField] private float idleDuration;
private float idleTimer;

private void Awake(){
    initScale = enemy.localScale;
}


private void OnDisable(){
    anim.SetBool("moving" , false);
}

private void Update(){

    if(MovingLeft){
        if(enemy.position.x >= leftEdge.position.x){

            MoveInDirection(-1);

        }
        else{

            DirectionChange(); 
        }
    }

    else{
        if(enemy.position.x <= rightEdge.position.x){
             MoveInDirection(1);
        }
        else{
            DirectionChange();
        }
    }
}

private void DirectionChange(){
    anim.SetBool("moving" , false);

    idleTimer += Time.deltaTime;

    if(idleTimer > idleDuration){
        MovingLeft = !MovingLeft;
    }

}

private void MoveInDirection(int direction){

    idleTimer = 0;

    anim.SetBool("moving" , true);

    enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * direction
     , initScale.y,initScale.z);

 
    enemy.position = new Vector3(enemy.position.x + Time.deltaTime * direction * speed , enemy.position.y , enemy.position.z);

}
}
