using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;


// HEALTH, MOVEMENT, DEATH CHECKS, EVERYTHING RELATED TO PLAYER

public class Player : MonoBehaviour {

    public float maxSpeed = 3f;
    public float speed = 50f;
    public float jumpPower = 250f;

    public bool grounded;
    public bool canDoubleJump;

    public int currentHealth;
    public int maxHealth = 5;

// refs
    private Rigidbody2D rb2d;
    private Animator anim;
    private CounterGame cg;
    private AudioSlider audio;


	void Start () {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        currentHealth = maxHealth;                          // level loadinimas ensurina žaidėjo max health.
        cg = GameObject.FindGameObjectWithTag("CounterGame").GetComponent<CounterGame>();
    }

	void Update ()
    {
    anim.SetBool("Grounded", grounded);                                                          // Tikrasis žaidėjo greitis.
    anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));                                             // Modelio pasisukimas
         if (Input.GetAxis("Horizontal") < -0.1f){
             transform.localScale = new Vector3(-0.07f, 0.07f, 0.07f); //transform.localScale.y
        }
         if (Input.GetAxis("Horizontal") > 0.1f){
             transform.localScale = new Vector3(0.07f, 0.07f, 0.07f);
         }

        if(Input.GetButtonDown("Jump")){
            if(grounded)
                {
                    rb2d.AddForce(Vector2.up * jumpPower);
                    canDoubleJump = true; 
                }
        else{
            if(canDoubleJump){
                canDoubleJump = false;
                rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
                rb2d.AddForce(Vector2.up * jumpPower);
            }
        }
    }
}


    void FixedUpdate()
{
        Vector3 easeVelocity = rb2d.velocity;
        easeVelocity.y = rb2d.velocity.y;                               //true speed
        easeVelocity.z = 0.0f;                                          //nenaudojam z
        easeVelocity.x *= 0.75f;                                        // friction, kiekvienas update ciklas užtikrina speedloss
            if(grounded)
        {
    rb2d.velocity = easeVelocity;                                       //Sukuriam friction
        }

        float h = Input.GetAxis("Horizontal");                                  // Moving the player
        rb2d.AddForce((Vector2.right * speed) * h);


        if(rb2d.velocity.x > maxSpeed){
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);             // Limiting speed of player
        }
  
        if (rb2d.velocity.x < -maxSpeed)
        {
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
        }

Vector2 moveDirection = new Vector2 (Input.GetAxisRaw ("Horizontal"), -0.1f);


    if(currentHealth > maxHealth){                                      // limitinam hp
        currentHealth = maxHealth;
    }
     
    if(currentHealth <= 0){                                             // mirties trigeris
        currentHealth = 0;
        deathCheck();
    }
}

    void deathCheck(){

        if(PlayerPrefs.HasKey("highscore"))
        {
            if(PlayerPrefs.GetInt("highscore") < cg.points)
            {
                PlayerPrefs.SetInt("highscore", cg.points);
            }
        }
        else
        {
            PlayerPrefs.SetInt("highscore", cg.points);
        }

        Application.LoadLevel(Application.loadedLevel);
    }

    public void Damage(int dmg)
    {
        currentHealth -= dmg;
        gameObject.GetComponent<Animation>().Play("redDamage");
    }


    public IEnumerator Knockback(float knockDuration, float knockPower, Vector3 knockDirection){                             //called for a specific amount of time IEnum

        float timer = 0;
        while(knockDuration > timer){
            timer+=Time.deltaTime;
            rb2d.AddForce(new Vector3(-(knockDirection.x) * 40, (-knockDirection.y) + knockPower, transform.position.z));
        }

    yield return 0;

    }


    void OnTriggerEnter2D(Collider2D col)
    {
            if(col.CompareTag("Coin")){
                Destroy(col.gameObject);
                cg.points += 1;
            }
    }



}
