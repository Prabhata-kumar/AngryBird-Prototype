
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: MonoBehaviour
{
   // public Animator animator;
    public float speed;
    public float Jump;
    private bool isGrounded ;
    public Vector2 velocity;
    public float acceleratation = 10;
    public float MaxAccliration = 10;
    public float MaxVelocity = 100;
    public float distance = 0;
   

    public void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");

        MoveCharacter(horizontal);
       // PlayMovementAnimation(horizontal);
        PlayerJump(vertical);
        Acclerate();
    }



    private void MoveCharacter(float horizontal)
    {
        //move the character in horizontaly
        Vector3 position = transform.position;
        position.x = position.x + horizontal * speed * Time.deltaTime;
        transform.position = position;
    }

    private void PlayMovementAnimation(float horizontal)
    {
        //running
        speed = Input.GetAxisRaw("Horizontal");//it desplay the the speed of a player = 1
        // animator.SetFloat("speed", Mathf.Abs(horizontal)); //in it real value

        Vector3 Scale = transform.localScale;//it is take the value from -x site it halp toward left site
        //(distance/sec)*(sec/30)

        if (horizontal < 0) Scale.x = -1f * Mathf.Abs(Scale.x);
        else if (horizontal > 0) Scale.x = Mathf.Abs(Scale.x);

        transform.localScale = Scale;

    }
    //jump
    void PlayerJump(float vertical)
    {
        if (vertical > 0.6f && isGrounded==true)
        {
            Vector3 position = transform.position;
            position.y = position.y + vertical * Jump * Time.deltaTime;
            transform.position = position;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Grounded")
        {
            isGrounded = true;
        }
    }

    void Acclerate()
    {
        if (isGrounded)
        {
            float velocityRatio = velocity.x / MaxVelocity;
            acceleratation = MaxAccliration * (1 - velocityRatio);

            velocity.x = acceleratation * Time.deltaTime; 
            if(velocity.x >= MaxVelocity)
            {
                velocity.x = MaxVelocity;
            } 
        }     
    }

}