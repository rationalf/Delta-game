using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController1_1 : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    private GameObject _enemy;
    private bool isFinished;
    
    private void OnTriggerEnter(Collider other)
    {
        if (_enemy == null && !isFinished)
        {
            Debug.Log("Trigger");
            _enemy = Instantiate(enemyPrefab, new Vector3(16.5f, 0.5f, -41), Quaternion.identity);
            isFinished = true;
        }
    }
}
