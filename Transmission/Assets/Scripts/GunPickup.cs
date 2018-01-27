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
            CombatActions playerObj = other.gameObject.GetComponent<CombatActions>();
            if (playerObj.HasWeapon())
                playerObj.ResetWeapon();
            playerObj.hasGun = true;
            playerObj.charge = charge;
            Destroy(gameObject);
        }
    }
}
