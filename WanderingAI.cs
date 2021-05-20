using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class WanderingAI : MonoBehaviour
{
    public float wanderRadius;
    public float wanderTimer;

    private Transform target;
    private NavMeshAgent agent;
    private float timer;

    // Use this for initialization
    void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= wanderTimer)
        {
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
            //Checks to ensure the agent hasn't already been tasked by the user.
            if (!agent.pathPending)
            {
                //Checks if it has reached/is close to reaching its goal.
                if (agent.remainingDistance <= agent.stoppingDistance)
                {
                    //Checks if the agent is moving
                    if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                    {
                        //If passes all the above, it will begin moving to its new random position
                        agent.SetDestination(newPos);
                    }
                }
            }
            timer = 0;
        }

    }


    //Handles getting a random coordinate inside a set size sphere.
    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;
        randDirection += origin;

        NavMeshHit navHit;
        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }
}