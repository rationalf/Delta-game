using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Moveandattack : MonoBehaviour
{
    GameObject player;
    NavMeshAgent agent;
    public Animator anim;

    [SerializeField] GameObject shootingPrefab;
    private GameObject _bullet;
    
    private float _lifeTimeCounter = 0;
    private float lifeTime = 0.75f;

    private float rotSpeed = 2f;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        
    }
    
    void Update()
    {
        _lifeTimeCounter += Time.deltaTime;
        
        if (Vector3.Distance(player.transform.position, agent.transform.position) > 8f)
        {
            anim.SetTrigger("walk");
            agent.isStopped = false;
            agent.SetDestination(player.transform.position);
        }
        else
        {
            agent.isStopped = true;
            Ray ray = new Ray(transform.position +
                              new Vector3(0, 1.5f, 0), transform.forward);
            RaycastHit hit;
            if (Physics.SphereCast(ray, 1f, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                if (hitObject.CompareTag("Player") && _lifeTimeCounter > lifeTime)
                {
                    _lifeTimeCounter = 0;
                    anim.SetTrigger("shoot");
                    _bullet = Instantiate(shootingPrefab) as GameObject;
                    _bullet.transform.position = transform.TransformPoint(
                        Vector3.forward * 1.5f
                        + new Vector3(0.25f, 1.5f, 0));
                    _bullet.transform.rotation = transform.rotation;
                }
                else
                {
                    anim.SetTrigger("stay");
                    agent.transform.rotation = Quaternion.Slerp(agent.transform.rotation,
                        Quaternion.LookRotation(player.transform.position-agent.transform.position), Time.deltaTime*rotSpeed);
                }
            }
            
        }
    }
}
