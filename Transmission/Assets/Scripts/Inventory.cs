using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public int crystals;
    public int guns;
    public int hammers;
    public int foodstocks;

    // Use this for initialization
    void Start () {
        crystals = 15;
        guns = 0;
        hammers = 0;
        foodstocks = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnGUI()
    {
        if (Application.isEditor)
        {
            GUI.skin.label.wordWrap = false;
            GUI.skin.label.clipping = 0;
            GUI.Label(new Rect(transform.position.x, transform.position.y, 100, 100), "crystals: "+crystals.ToString()+"\nguns: " + guns.ToString()+ "\nhammers: " + hammers.ToString()+ "\nfoodstocks: " + foodstocks.ToString());
        }
    }
}
