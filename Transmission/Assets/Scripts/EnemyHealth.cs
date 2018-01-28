using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public int health = 100;
    public GameObject player;
    private CombatActions1 playerActions;

    public bool canHit = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Melee")
        {
            canHit = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Melee")
        {
            canHit = false;
        }
    }

    private void Start()
    {
        playerActions = player.GetComponent<CombatActions1>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            //destroy this object
            Destroy(gameObject);
        }

        if (Input.GetButtonDown("Joy1_Fire1") && canHit && playerActions.hasHammer)
        {
            health -= 20;

            int x = 0;
            int y = 0;
            if (player.gameObject.transform.position.x < transform.position.x - .25)
            {
                x = 10;
            }
            else if (player.gameObject.transform.position.x > transform.position.x + .25)
            {
                x = -10;
            }

            if (player.gameObject.transform.position.y < transform.position.y - .25)
            {
                y = 10;
            }
            else if (player.gameObject.transform.position.y > transform.position.y + .25)
            {
                y = -10;
            }

            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(x, y) * 100);
        }

    }
}
