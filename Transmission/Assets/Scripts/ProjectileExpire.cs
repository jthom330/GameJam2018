using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileExpire : MonoBehaviour {

    private float destroyDelay = 3.0f;

	// Use this for initialization
	void Start () {
        Object.Destroy(gameObject, destroyDelay);
    }
	
	
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHealth>().health -= 10;
            int x = 0;
            int y = 0;
            if (collision.gameObject.transform.position.x < transform.position.x - .25)
            {
                x = -10;
            }
            else if (collision.gameObject.transform.position.x > transform.position.x + .25)
            {
                x = 10;
            }

            if (collision.gameObject.transform.position.y < transform.position.y -.25)
            {
                y = -10;
            }
            else if (collision.gameObject.transform.position.y > transform.position.y + .25)
            {
                y = 10;
            }

            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(x, y) * 100);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Obstacle")
        {
            
            Destroy(gameObject);
        }

    }
}
