using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockInstantiator : MonoBehaviour
{
    public int maxStageRocks;
    public int currentRockCount;
    public GameObject[] rocks;

    // Use this for initialization
    void Start()
    {
        maxStageRocks = 100;
        currentRockCount = 0;
        SpawnRocksOnStart();
    }

    // Update is called once per frame
    void Update()
    {
        RefillRocks();
    }

    void SpawnRocksOnStart()
    {
        for (currentRockCount = 0; currentRockCount < maxStageRocks; currentRockCount++)
        {
            GameObject newRock = rocks[Random.Range(0, rocks.Length)];
            GameObject stageRocks = Instantiate(newRock, transform.position, Quaternion.identity);
            stageRocks.transform.parent = gameObject.transform;
        }
    }

    void RefillRocks()
    {
        if (currentRockCount < maxStageRocks)
        {
            GameObject newRock = rocks[Random.Range(0, rocks.Length)];
            GameObject stageRocks = Instantiate(newRock, transform.position, Quaternion.identity);
            stageRocks.transform.parent = gameObject.transform;
            currentRockCount++;
        }
    }
}
