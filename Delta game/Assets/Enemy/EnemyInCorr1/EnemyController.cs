using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    private GameObject _enemy;
    
    
    private void OnTriggerEnter(Collider other)
    {
        if (_enemy == null)
        {
            Debug.Log("Trigger");
            _enemy = Instantiate(enemyPrefab, new Vector3(0, 0.5f, -25), Quaternion.identity);
            //_enemy.transform.position = new Vector3(0, 0.5f, -25);
        }
    }
}
