using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public Rigidbody2D enemy;

    private float xPrev;
    private float yPrev;
    private Animator anim;

    // Use this for initialization
	void Start () {
        xPrev = transform.position.x;
        yPrev = transform.position.y;

        anim = gameObject.GetComponent<Animator>();

        //gameObject.GetComponent<>();
    }
	
	// Update is called once per frame
	void LateUpdate () {
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    private void Update()
    {
        if (xPrev > transform.position.x)
        {
            //left
            anim.SetInteger("direction", 1);
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        if (xPrev < transform.position.x)
        {
            //right
            anim.SetInteger("direction", 1);
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        if (yPrev > transform.position.y)
        {
            //down
            anim.SetInteger("direction", 0);

        }
        if (yPrev < transform.position.y)
        {
            //up
            anim.SetInteger("direction", 2);

        }

        xPrev = transform.position.x;
        yPrev = transform.position.y;

        Vector2 targetVelocity = new Vector2(0, 0);
        gameObject.GetComponent<Rigidbody2D>().velocity = targetVelocity;
    }
}
