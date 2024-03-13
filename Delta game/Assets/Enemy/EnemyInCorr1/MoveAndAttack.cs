using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Moveandattack : MonoBehaviour
{
    GameObject player;
    NavMeshAgent agent;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        
    }
    
    void Update()
    {
        agent.SetDestination(player.transform.position);
    }
}
