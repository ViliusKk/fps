using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform target;
    public float damageStopTime = 2f;

    public float attackLength = 1.5f;
    public int damage = 10;
    public float attackCooldown = 0.5f;
    
    private NavMeshAgent agent;
    private Animator animator;
    private bool attacking;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        if (target != null && agent.enabled)
        {
            agent.SetDestination(target.position);
        }
        
        var distance = Vector3.Distance(transform.position, target.position);
        animator.SetBool("isStopped", distance - agent.stoppingDistance < 0.3f);

        if (distance - agent.stoppingDistance < 0.3f)
        {
            StartCoroutine(Attack());
        }
    }

    public void TakeDamage()
    {
        animator.Play("Pain");
        StartCoroutine(WaitAndStop());
    }

    IEnumerator WaitAndStop()
    {
        agent.enabled = false;
        yield return new WaitForSeconds(damageStopTime);
        agent.enabled = true;
    }

    public void Die()
    {
        agent.enabled = false;
        animator.Play("Death");
        Destroy(this);
    }

    IEnumerator Attack()
    {
        attacking = true;
        agent.enabled = false;
        animator.Play("Attack");
        yield return new WaitForSeconds(attackLength);
        
        var health = target.gameObject.GetComponent<Health>();
        if (health != null) health.TakeDamage(damage);
        
        yield return new WaitForSeconds(attackCooldown);
        attacking = false;
        agent.enabled = true;
    }
}
