using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalSpawner : MonoBehaviour {

    public GameObject[] spawners;
    public GameObject crystalDrop;
    public int tickSpeed = 5;

    // Use this for initialization
    void Start () {
        StartCoroutine(idle());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Joy1_Fire2"))
        {
            SpawnCrystalRandomly();
        }
    }

    public void SpawnCrystalRandomly()
    {
        GameObject spawner = spawners[Random.Range(0, spawners.Length)];
        Debug.Log("spawner: "+ spawner.transform.position);
        Instantiate(crystalDrop, spawner.transform.position, Quaternion.identity);
    }

    void OnGUI()
    {
        if (Application.isEditor)
        {
            GUI.skin.label.wordWrap = false;
            GUI.skin.label.clipping = 0;
            GUI.Label(new Rect(4, 16 * 5, 100, 100), "spawners: " + spawners.GetValue(0).ToString());
        }
    }

    IEnumerator idle()
    {
        for (;;)
        {
            yield return new WaitForSeconds(tickSpeed);
            SpawnCrystalRandomly();
        }
    }
}
