 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Protagonista : MonoBehaviour
{

    public Rigidbody2D myRigidBody;

    public BoxCollider2D coll;

    public Joystick joystick;


    public Animator anim;

    public enum StatoMovimento {Idle1 , Corsa1 , Salto1};

    [SerializeField] private AudioSource jumpSpundEffect;
    public float Direzione = 0f;

    public SpriteRenderer Sprite;

    [SerializeField] public LayerMask TerraSaltabile;

    [SerializeField] private AudioSource MorteSuono;

    [SerializeField] public float VelocitàMovimento = 5f;
    [SerializeField] public float VelocitàSalto = 13f;

    // Start is called before the first frame update
    void Start()
    {
      myRigidBody = GetComponent<Rigidbody2D>();

      Sprite = GetComponent<SpriteRenderer>();

        coll = GetComponent<BoxCollider2D>();

        anim = GetComponent<Animator>();


    }

    // Update is called once per frame
 private void Update()
    {

      float verticalMove = joystick.Vertical;

        //Space per il Salto
        if(verticalMove>=.5f && ControlloSalto()){
         jumpSpundEffect.Play();
     myRigidBody.velocity = new Vector2(myRigidBody.velocity.x,VelocitàSalto);  
        }


        //A e D per il movimento laterale
        Direzione = joystick.Horizontal;

       // Destra
    myRigidBody.velocity = new Vector2(Direzione * VelocitàMovimento ,myRigidBody.velocity.y);

    AggiornoAnimazione();
}

private void AggiornoAnimazione(){
   StatoMovimento stato;
   if (Direzione > 0f){
      stato = StatoMovimento.Corsa1;
      Sprite.flipX = false;
   }
   else if(Direzione<0f){
      stato = StatoMovimento.Corsa1;
      Sprite.flipX = true;
   }

   else{
      stato = StatoMovimento.Idle1;
   }

   if (myRigidBody.velocity.y > .1f){
stato = StatoMovimento.Salto1;
   }

   anim.SetInteger("Stato" , (int)stato);
}

//Controllo Salto
private bool ControlloSalto(){
   return Physics2D.BoxCast(coll.bounds.center , coll.bounds.size , 0f , Vector2.down , .1f , TerraSaltabile);
}
//Morte Giocatore

private void OnCollisionEnter2D(Collision2D collision){
   if(collision.gameObject.CompareTag("Ostacoli") || collision.gameObject.CompareTag("Bordo")){
      Morte();
      MorteSuono.Play();
   }

}


private void Morte(){
anim.SetTrigger("Morte");
myRigidBody.bodyType = RigidbodyType2D.Static;
}

private void Restart(){
SceneManager.LoadScene(SceneManager.GetActiveScene().name);
}



}







