using System;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform target;
    
    private NavMeshAgent agent;
    private Animator animator;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (target != null)
        {
            agent.SetDestination(target.position);
        }
        
        var distance = Vector3.Distance(transform.position, target.position);
        animator.SetBool("isStopped", distance - agent.stoppingDistance < 0.3f);
    }
}
