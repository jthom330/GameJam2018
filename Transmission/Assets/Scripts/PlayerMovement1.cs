using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement1 : MonoBehaviour {

    public float playerSpeed = 4f;
    public Rigidbody2D player;
    public Transform center;
    Animator anim;

    private bool horizontalOpen = true;
    private bool verticalOpen = true;

   
    int jumpHash = Animator.StringToHash("Jump");
    int runStateHash = Animator.StringToHash("Base Layer.Run");


    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Joy1_Horizontal");
        float y = Input.GetAxisRaw("Joy1_Vertical");



        if (x == 0)
        {
            //stop
            horizontalOpen = true;
        }
        if (x > 0 && verticalOpen)
        {
            //right
            horizontalOpen = false;
            center.rotation = Quaternion.Euler(0, 0, 90);
            anim.SetInteger("direction", 1);
            //anim.ResetTrigger("side");
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        if (x < 0 && verticalOpen)
        {
            //left
            horizontalOpen = false;
            center.rotation = Quaternion.Euler(0, 0, 270);
            anim.SetInteger("direction", 1);

            //anim.ResetTrigger("side");
            gameObject.GetComponent<SpriteRenderer>().flipX = false;

        }
        if (y == 0)
        {
            //stop
            verticalOpen = true;
        }
        if (y > 0 && horizontalOpen)
        {
            //up
            verticalOpen = false;
            center.rotation = Quaternion.Euler(0, 0, 180);
            anim.SetInteger("direction", 2);

            // anim.ResetTrigger("up");

        }
        if (y < 0 && horizontalOpen)
        {
            //down
            verticalOpen = false;
            center.rotation = Quaternion.Euler(0, 0, 0);
            anim.SetInteger("direction", 0);

            //anim.ResetTrigger("down");

        }

        if (x == 0 && y == 0)
        {
            anim.SetBool("moving", false);
        }
        else
        {
            anim.SetBool("moving", true);
        }

        Vector2 targetVelocity = new Vector2(x, y);
        player.velocity = targetVelocity * playerSpeed;
    }
}
