﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjects : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void destroyObjects()
    {
        //Creates an array of every object marked as Destructable
        GameObject[] destroyableObjects = GameObject.FindGameObjectsWithTag("Destructable");
        //Goes through and deletes each item in this array
        foreach (GameObject destroyableObject in destroyableObjects)
            GameObject.Destroy(destroyableObject);
    }
}
