using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptProtagonista : MonoBehaviour
{

    public Rigidbody2D myRigidBody;

    private BoxCollider2D coll;

    private Animator Animation;

    public float Direzione = 0f;

    [SerializeField] private LayerMask TerraSaltabile;


    [SerializeField] public float VelocitàMovimento = 5f;
    [SerializeField] public float VelocitàSalto = 13f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
 private void Update()
    {
        //Space per il Salto
        if(Input.GetButtonDown("Jump") && ControlloSalto()){
     myRigidBody.velocity = new Vector2(myRigidBody.velocity.x,VelocitàSalto);  
        }


        //A e D per il movimento laterale
        Direzione = Input.GetAxis("Horizontal");

       // Destra
    myRigidBody.velocity = new Vector2(Direzione * VelocitàMovimento , myRigidBody.velocity.y);
}

private bool ControlloSalto(){
   return Physics2D.BoxCast(coll.bounds.center , coll.bounds.size , 0f , Vector2.down , .1f , TerraSaltabile);
}
}
