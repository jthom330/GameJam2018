using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatActions1 : MonoBehaviour {

    public GameObject gunDrop;
    public GameObject hammerDrop;
    public Rigidbody2D projectile;
    public Transform centerPoint;
    public Transform bulletOrigin;

    public bool hasGun;
    public bool hasHammer;
    public int charge;

    // Use this for initialization
    void Start() {
        hasGun = false;
        hasHammer = false;
        charge = 0;
    }
	
	// Update is called once per frame
	void Update() {
        if (Input.GetButtonDown("Joy1_Fire1")) {
            if (HasWeapon()) {
                // weapon logic
                if (hasGun) {
                    Rigidbody2D clone;
                    clone = Instantiate(projectile, bulletOrigin.position, centerPoint.rotation) as Rigidbody2D;
                    clone.velocity = transform.TransformDirection(centerPoint.up * -10);
                }
                // cleanup
                charge -= 1;
                if (charge <= 0)
                    ResetWeapon();
            }
        }
    }

    void OnGUI() {
        if (Application.isEditor) {
            //var myObject : GameObject = GameObject.Find("myObject");

            GUI.skin.label.wordWrap = false;
            GUI.skin.label.clipping = 0;
            GUI.Label(new Rect(4, 16*0, 100, 100), "hasGun: "+hasGun.ToString());
            GUI.Label(new Rect(4, 16*1, 100, 100), "hasHammer: "+hasHammer.ToString());
            GUI.Label(new Rect(4, 16*2, 100, 100), "HasWeapon: "+HasWeapon().ToString());
            GUI.Label(new Rect(4, 16*3, 100, 100), "charge: "+charge.ToString());
        }
    }

    public void ResetWeapon() {
        if (charge > 0) {
            if (hasGun) {
                GameObject instance = Instantiate(gunDrop, centerPoint.up * 0.5f, Quaternion.identity);
                instance.GetComponent<GunPickup>().charge = charge;
            }
            else if (hasHammer) {
                GameObject instance = Instantiate(hammerDrop, centerPoint.up * 0.5f, Quaternion.identity);
                instance.GetComponent<MeleePickup>().charge = charge;
            }
        }
        hasGun = false;
        hasHammer = false;
        charge = 0;
    }

    public bool HasWeapon() {
        if (hasGun || hasHammer)
            return true;
        else
            return false;
    }
}
