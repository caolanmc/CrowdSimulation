using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAgents : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void destroyAgents()
    {
        //Creates an array of game objects tagged with Agent.
        GameObject[] destroyableAgents = GameObject.FindGameObjectsWithTag("Agent");
        //Goes through this array and deletes each agent.
        foreach (GameObject destroyableAgent in destroyableAgents)
            GameObject.Destroy(destroyableAgent);
    }
}
