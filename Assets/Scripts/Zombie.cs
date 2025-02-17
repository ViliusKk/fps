using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    public GameObject gun;
    public Transform target;
    public int patrolDistance = 5;
    public int viewDistance = 20;
    public Transform muzzle;
    public GameObject bulletPrefab;
    public AudioSource gunSound;
    
    private NavMeshAgent agent;
    private Animator animator;
    private bool canShoot = true;
    
    Vector3 randomDestination;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        gun.SetActive(false);
        target = GameObject.FindGameObjectWithTag("Player").transform;
        
        InvokeRepeating(nameof(RandomDestination), 3f, 3f);
        randomDestination = transform.position;
    }
    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);
        float yRotation = transform.rotation.y;

        if (distance <= viewDistance)
        {
            agent.SetDestination(target.position);
            animator.SetBool("nearTarget", true);
            gun.SetActive(true);
        }
        else
        {
            agent.SetDestination(randomDestination);
            animator.SetBool("nearTarget", false);
            gun.SetActive(false);
        }

        if (distance <= 5 && canShoot)
        {
            animator.SetBool("shoot", true);
            Instantiate(bulletPrefab, muzzle.position, transform.rotation);
            gunSound.Play();
            StartCoroutine(Cooldown());
        }
        else
        {
            animator.SetBool("shoot", false);
        }
    }
    
    void RandomDestination()
    {
        randomDestination.x += Random.Range(-1f,1f) * patrolDistance;
        randomDestination.y += Random.Range(-1f, 1f) * patrolDistance;
    }

    IEnumerator Cooldown()
    {
        canShoot = false;
        yield return new WaitForSeconds(1);
        canShoot = true;
    }
}
