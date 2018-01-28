using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour {

    public GameObject[] spawners;
    public GameObject MonsterSpawn;
    public int tickSpeed = 5;

    // Use this for initialization
    void Start () {
        StartCoroutine(idle());
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SpawnMonsterRandomly()
    {
        GameObject spawner = spawners[Random.Range(0, spawners.Length)];
        Debug.Log("Monster@spawner: "+ spawner.transform.position);
        Instantiate(MonsterSpawn, spawner.transform.position, Quaternion.identity);
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
            SpawnMonsterRandomly();
        }
    }
}
