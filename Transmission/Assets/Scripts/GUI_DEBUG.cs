using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUI_DEBUG : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnGUI()
    {
        if (Application.isEditor)
        {
            //var myObject : GameObject = GameObject.Find("myObject");

            GUI.skin.label.wordWrap = false;
            GUI.skin.label.clipping = 0;
            GUI.Label(new Rect(4, 16 * 4, 100, 100), "Fire1: " + Input.GetButtonDown("Joy1_Fire1").ToString());
        }
    }
}
