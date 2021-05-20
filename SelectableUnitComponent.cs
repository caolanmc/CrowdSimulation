using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

//Credit to https://github.com/knopkem

public class SelectableUnitComponent : MonoBehaviour
{
    public Transform target;
    public GameObject selectionCircle;
    private NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public bool isSelected()
    {
        return (selectionCircle != null);
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            agent.destination = target.position;
            Destroy(target.gameObject);
        }

    }
}