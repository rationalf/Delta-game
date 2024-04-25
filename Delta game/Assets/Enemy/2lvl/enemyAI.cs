using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
public class enemyAI : MonoBehaviour
{
    Transform target;
    NavMeshAgent agent;
    public float LookRadius;
    [SerializeField] public GameObject player;
    private float damage = 0.1f;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (player!=null)
            target = player.transform;
        else
            StartCoroutine(startDelay());
    }

    private void Update()
    {
        
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= LookRadius)
        {
            agent.SetDestination(target.position);
            agent.speed = 7f;
            if (distance <= agent.stoppingDistance)
            {
                LookTarget();
            }
        }
    }

    void LookTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x,0,direction.y));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerStatistics>().TakeDamage(damage);
        }
    }

    private IEnumerator startDelay()
    {
        yield return new WaitForSeconds(1);
    }
}
