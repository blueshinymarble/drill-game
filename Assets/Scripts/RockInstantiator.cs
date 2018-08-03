using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockInstantiator : MonoBehaviour
{
    public int maxStageRocks;
    public GameObject[] rocks;

    // Use this for initialization
    void Start()
    {
        maxStageRocks = 100;
        SpawnRocksOnStart();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRocksOnStart()
    {
        for (int i = 0; i < maxStageRocks; i++)
        {
            GameObject newRock = rocks[Random.Range(0, rocks.Length)];
            GameObject stageRocks = Instantiate(newRock, transform.position, Quaternion.identity);
            stageRocks.transform.parent = gameObject.transform;
        }
    }
}
