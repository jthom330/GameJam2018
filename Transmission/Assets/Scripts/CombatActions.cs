using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatActions : MonoBehaviour {


    public Rigidbody2D projectile;
    public Transform centerPoint;
    public Transform bulletOrigin;

    public bool hasGun = false;
    public bool hasHammer = false;

    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            Rigidbody2D clone;
            clone = Instantiate(projectile, bulletOrigin.position, centerPoint.rotation) as Rigidbody2D;
            clone.velocity = transform.TransformDirection(centerPoint.up * -10);
        }
    }
}
