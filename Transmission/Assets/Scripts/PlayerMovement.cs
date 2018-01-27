using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float playerSpeed = 4f;
    public Rigidbody2D player;
    public Transform center;

    private bool horizontalOpen = true;
    private bool verticalOpen = true;


    // Use this for initialization
    void Start () {
		
	}

    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

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
        }
        if (x < 0 && verticalOpen)
        {
            //left
            horizontalOpen = false;
            center.rotation = Quaternion.Euler(0, 0, 270);

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

        }
        if (y < 0 && horizontalOpen)
        {
            //right
            verticalOpen = false;
            center.rotation = Quaternion.Euler(0, 0, 0);

        }

        Vector2 targetVelocity = new Vector2(x, y);
        player.velocity = targetVelocity * playerSpeed;
    }
}
