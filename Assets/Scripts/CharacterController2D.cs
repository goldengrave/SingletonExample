using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class CharacterController2D : MonoBehaviour
{
    public float speed;
    public float jumpPower;
    private float xVel, yVel;
    Rigidbody2D rb2d;
    public bool grounded = false;
    private bool jumping = false;
    public GameObject GroundCheckL,GroundCheckR;
    public LayerMask GroundLayer;
    public SpriteRenderer ourSprite;



    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        xVel = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && grounded)
        {
            jumping = true;
        }

        bool groundedL = Physics2D.Linecast(transform.position, GroundCheckL.transform.position,GroundLayer);
        bool groundedR = Physics2D.Linecast(transform.position, GroundCheckR.transform.position, GroundLayer);

        if(groundedL|| groundedR)
        {
            grounded = true;
        }
        else
        {
            print("here");
            grounded = false;
            transform.SetParent(null);

        }


        //Flip();
    }


    private void FixedUpdate()
    {
        if (jumping && grounded)
        {
            rb2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jumping = false;
 

        }
   
            rb2d.velocity = new Vector2(xVel * speed, rb2d.velocity.y);
        
      

    }

    private void Flip()
    {
        if (rb2d.velocity.x > 0.2f)
        {
            ourSprite.flipX = false;
        }
        else if(rb2d.velocity.x < -0.2f)
        {
            ourSprite.flipX = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {


        print(collision.gameObject.layer);
        if (collision.gameObject.layer == 6) { 
            transform.SetParent( collision.gameObject.transform);
        }



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }
    private void HurtCoolDown()
    {
    }

    private void takeDamage(int dmg)
    {
        Invoke("HurtCoolDown", 2);
    }

 
}

