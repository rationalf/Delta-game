using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    private GameObject _enemy;
    private bool isFinished;
    
    private void OnTriggerEnter(Collider other)
    {
        if (_enemy == null && !isFinished)
        {
            Debug.Log("Trigger");
            _enemy = Instantiate(enemyPrefab, new Vector3(0, 0.5f, -25), Quaternion.identity);
            isFinished = true;
        }
    }
}
