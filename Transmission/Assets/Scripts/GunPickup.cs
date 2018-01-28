using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickup : MonoBehaviour {

    public int charge;

    // Use this for initialization
    void Start() {}
	
	// Update is called once per frame
	void Update() {}

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            CombatActions1 playerObj = other.gameObject.GetComponent<CombatActions1>();
            if (playerObj.HasWeapon())
                playerObj.ResetWeapon();
            playerObj.hasGun = true;
            playerObj.charge = charge;
            Destroy(gameObject);
        }
        //crap to quickly create a player2
        if (other.gameObject.CompareTag("Player2")) {
            CombatActions2 playerObj = other.gameObject.GetComponent<CombatActions2>();
            if (playerObj.HasWeapon())
                playerObj.ResetWeapon();
            playerObj.hasGun = true;
            playerObj.charge = charge;
            Destroy(gameObject);
        }
    }
}
