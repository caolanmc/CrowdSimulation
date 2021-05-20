using TMPro;
using UnityEngine;

public class AgentCount : MonoBehaviour
{
    public TextMeshProUGUI agentText;
    int numberOfAgents;

    void Start()
    {
        agentText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject[] agents = GameObject.FindGameObjectsWithTag("Agent");
            numberOfAgents = agents.Length;
            agentText.text = "Agents: " + numberOfAgents.ToString();
        }
    }
}
