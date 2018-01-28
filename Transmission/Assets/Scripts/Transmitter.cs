using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transmitter : MonoBehaviour {

    public SpriteRenderer dpadRenderer;

    public Sprite dpad;
    public Sprite[] dpad_dirs;
    public AudioClip teleport;
    public AudioClip fail;

    private AudioSource audioSource;

    public GameObject Player2;

    private bool transmissionStarted = false;
    private bool transportedLocked = false;
    private int[] inputs = new int[5];
    private int[] checks = new int[5] { -1,-1,-1,-1,-1};
    private bool correct = true;
    private int currentIteration = 1;
    private int inputCount = 0;

    private bool inputLock = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            transmissionStarted = true;
            Player2.GetComponent<PlayerMovement2>().enabled = false;
        }
    }

    // Use this for initialization
    void Start () {
        audioSource = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

        if (transmissionStarted && transportedLocked == false)
        {
            dpadRenderer.enabled = true;
            StartCoroutine("Transport");
        }

        float x = Input.GetAxisRaw("Joy2_Horizontal");
        float y = Input.GetAxisRaw("Joy2_Vertical");


        if (transmissionStarted && transportedLocked && inputCount < 5 && inputLock == false)
        {
            if (x > 0)
            {
                //right
                checks[inputCount] = 3;
                inputCount++;
                inputLock = true;
                StartCoroutine("InputLock");

            }
            if (x < 0)
            {
                //left     
                checks[inputCount] = 2;
                inputCount++;
                inputLock = true;
                StartCoroutine("InputLock");

            }
            if (y > 0)
            {
                //up    
                checks[inputCount] = 0;
                inputCount++;
                inputLock = true;
                StartCoroutine("InputLock");

            }
            if (y < 0)
            {
                //down  
                checks[inputCount] = 1;
                inputCount++;
                inputLock = true;
                StartCoroutine("InputLock");

            }
        }

    }

    IEnumerator InputLock()
    {
        yield return new WaitForSeconds(0.2f);
        inputLock = false;
    }

        IEnumerator Transport()
    {
        transportedLocked = true;
        correct = true;

        for (int i = 0; i < currentIteration; i++)
        {
            System.Random rnd = new System.Random();
            inputs[i] = rnd.Next(4);

            dpadRenderer.sprite = dpad_dirs[inputs[i]];

            yield return new WaitForSeconds(0.6f);
            dpadRenderer.sprite = dpad;
            yield return new WaitForSeconds(0.4f);
        }

        dpadRenderer.sprite = dpad;
        inputCount = 0;
        yield return new WaitForSeconds(2f);

        for (int i = 0; i < currentIteration; i++)
        {
            Debug.Log(inputs[i] + "  " + checks[i]);
            if (inputs[i] != checks[i])
            {
                correct = false;
                checks[i] = -1;
            }


        }

        if (correct)
        {
            if (currentIteration < 5)
            {
                currentIteration++;
                StartCoroutine("Transport");
            }
            else
            {
                //success
                //spawn items 
                //empty inventory

                audioSource.PlayOneShot(teleport);

                currentIteration = 1;
                transportedLocked = false;
                transmissionStarted = false;
                dpadRenderer.enabled = false;

                //turn on movement
                Player2.GetComponent<PlayerMovement2>().enabled = true;

            }
        }
        else
        {
            currentIteration = 1;
            //empty items
            //fail sound
            audioSource.PlayOneShot(fail);
            currentIteration = 1;
            transportedLocked = false;
            transmissionStarted = false;
            dpadRenderer.enabled = false;

            //turn on movement
            Player2.GetComponent<PlayerMovement2>().enabled = true;

        }


    }

}
