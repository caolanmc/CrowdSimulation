using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agent;
    public Animator PlayerController;
    bool aRunning = false;

    void Start()
    {
        PlayerController = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        //Sets the agent's speed randomly (default speed 1f), to add some crowd diversity.
        agent.speed = Random.Range(.8f, 1.5f);
    }

    void Update()
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
            {
                aRunning = false;
            }
            else
            {
                aRunning = true;
            }
            PlayerController.SetBool("aRunning", aRunning);
    }
}
