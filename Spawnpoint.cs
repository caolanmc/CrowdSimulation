using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnpoint : MonoBehaviour
{

    public GameObject spawnee;
    public GameObject SelectableObjects;
    public bool stopSpawning = false;
    public float spawnTime = 3;
    public float spawnDelay = 3;

    void Start()
    {
        //Repeats the Spawn Object method after x delay and repeates it every y seconds.
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
    }

    public void SpawnObject()
    {
        Instantiate(spawnee, transform.position, transform.rotation);
        if (stopSpawning)
        {
            CancelInvoke("SpawnObject");
        }
    }
}
