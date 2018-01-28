using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transmitter : MonoBehaviour {

    public SpriteRenderer dpadRenderer;

    public Sprite dpad;
    public Sprite[] dpad_dirs;
    //public Sprite dpad_down;
    //public Sprite dpad_left;
    //public Sprite dpad_right;

    public GameObject Player2;

    private bool transmissionStarted = false;
    private bool transportedLocked = false;
    private int[] inputs = new int[5];
    private int currentIteration = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            transmissionStarted = true;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (transmissionStarted)
        {
            dpadRenderer.enabled = true;
            StartCoroutine("Fade");
        }
		
	}

    IEnumerator Fade()
    {
        transportedLocked = true;

        for (int i = 0; i < currentIteration; i++)
        {
            System.Random rnd = new System.Random();
            inputs[i] = rnd.Next(4);

            dpadRenderer.sprite = dpad_dirs[inputs[i]];

            yield return new WaitForSeconds(0.6f);

        }

        yield return new WaitForSeconds(2f);



        transportedLocked = false;
        dpadRenderer.enabled = false;
    }

}
