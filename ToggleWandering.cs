using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleWandering : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toggleAgentsWander()
    {
        //Turns on and off the WanderingAI script each press of the button
        GameObject[] agentsToggle = GameObject.FindGameObjectsWithTag("Agent");
        foreach (GameObject agentToggle in agentsToggle)
            agentToggle.GetComponent<WanderingAI>().enabled = !agentToggle.GetComponent<WanderingAI>().enabled;
    }
}
