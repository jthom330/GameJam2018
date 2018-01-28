using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine : MonoBehaviour {

    public GameObject inventory;
    public int drop;
    public int tickSpeed = 5;
    public int maxTickSpeed = 5;
    public bool inRange = false;

    // Use this for initialization
    void Start () {
        StartCoroutine(idle());
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange)
        {
            if (Input.GetButtonDown("Joy2_Fire1"))
            {
                if (inventory.GetComponent<Inventory>().crystals > 0 && tickSpeed > 0) {
                    inventory.GetComponent<Inventory>().crystals -= 1;
                    tickSpeed -= 1;
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        inRange = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        inRange = false;
    }

    void OnGUI()
    {
        if (Application.isEditor)
        {
            GUI.skin.label.wordWrap = false;
            GUI.skin.label.clipping = 0;
            GUI.Label(new Rect(transform.position.x, 178, 100, 100), "inRange: " + inRange.ToString()+"\ntickSpeed: "+tickSpeed.ToString()+ "\nmaxTickSpeed: "+maxTickSpeed.ToString());
        }
    }

    public void SpawnDrop()
    {
        Debug.Log("spawner: "+ transform.position);
        //Instantiate(drop, transform.position, Quaternion.identity);
        //add drop to inventory
        if (drop==1)
            inventory.GetComponent<Inventory>().guns += 1;
        else if (drop==2)
            inventory.GetComponent<Inventory>().hammers += 1;
        else
            inventory.GetComponent<Inventory>().foodstocks += 1;
    }

    IEnumerator idle()
    {
        for (;;)
        {
            yield return new WaitForSeconds(tickSpeed);
            SpawnDrop();
            if (tickSpeed <= maxTickSpeed)
                tickSpeed = maxTickSpeed;
        }
    }
}
