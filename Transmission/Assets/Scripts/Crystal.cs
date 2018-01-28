using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject inv = other.gameObject.GetComponent<CombatActions1>().inventory;
            inv.gameObject.GetComponent<Inventory>().crystals += 1;
            Destroy(gameObject);
        }
    }
}
