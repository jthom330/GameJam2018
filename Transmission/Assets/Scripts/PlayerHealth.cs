using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public int health = 100;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            health -= 10;
            int x = 0;
            int y = 0;
            if (collision.gameObject.transform.position.x < transform.position.x - .25)
            {
                x = 10;
            }
            else if(collision.gameObject.transform.position.x > transform.position.x + .25)
            {
                x = -10;
            }

            if (collision.gameObject.transform.position.y < transform.position.y - .25)
            {
                y = 10;
            }
            else if (collision.gameObject.transform.position.y > transform.position.y + .25)
            {
                y = -10;
            }

            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(x, y) * 100);
        }
    }

    // Update is called once per frame
    void Update () {
        if(health <= 0)
        {
            //game over state
        }
		
	}
}
