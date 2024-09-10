using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class CarController : MonoBehaviour
{
    public float speed;
    public float jumpPower;
    private float xVel, yVel;
    Rigidbody2D rb2d;
    public bool grounded = false;
    private bool jumping = false;
    public GameObject GroundCheckL, GroundCheckR;
    public LayerMask GroundLayer;
    public WheelJoint2D rightWheel, leftWheel;
    private JointMotor2D rightMotor, leftMotor;




    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rightMotor = rightWheel.motor;
        leftMotor = leftWheel.motor;

    }

    // Update is called once per frame
    void Update()
    {
        xVel = Input.GetAxis("Horizontal");
        print(xVel);

        if (Input.GetButtonDown("Jump") && grounded)
        {
            jumping = true;
        }

        bool groundedL = Physics2D.Linecast(transform.position, GroundCheckL.transform.position, GroundLayer);
        bool groundedR = Physics2D.Linecast(transform.position, GroundCheckR.transform.position, GroundLayer);

        if (groundedL || groundedR)
        {
            grounded = true;
        }
        else
        {
            grounded = false;
            transform.SetParent(null);

        }

    }


    private void FixedUpdate()
    {
        if (jumping && grounded)
        {
            rb2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jumping = false;


        }

        if (xVel > 0)
        {
            print("heres");
            rightMotor.motorSpeed = 500;
            leftMotor.motorSpeed = 500;
        }
        else if (xVel < 0)
        {
            rightMotor.motorSpeed =-speed;
            leftMotor.motorSpeed =-speed;
        }
        else
        {
            rightMotor.motorSpeed = 0;
            leftMotor.motorSpeed = 0;
        }



    }



    private void OnCollisionEnter2D(Collision2D collision)
    {


        print(collision.gameObject.layer);
        if (collision.gameObject.layer == 6)
        {
            transform.SetParent(collision.gameObject.transform);
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

