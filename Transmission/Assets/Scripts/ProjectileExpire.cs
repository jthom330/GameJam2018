using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileExpire : MonoBehaviour {

    private float destroyDelay = 3.0f;

	// Use this for initialization
	void Start () {
        Object.Destroy(gameObject, destroyDelay);
    }
	
	
    void OnCollisionEnter(Collision collision)
    {
        //ContactPoint contact = collision.contacts[0];
        //Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        //Vector3 pos = contact.point;
        //Instantiate(explosionPrefab, pos, rot);
        Destroy(gameObject);
    }
}
