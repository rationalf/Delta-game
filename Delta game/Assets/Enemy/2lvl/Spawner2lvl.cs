using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner2lvl : MonoBehaviour
{
    private int maxNumEnemies = 3;
    public static int numEnemies = 0;

    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < maxNumEnemies-1; i++)
        {
            GameObject currEnemy = Instantiate(enemy, transform.position, Quaternion.identity);
            currEnemy.GetComponent<enemyAI>().player = _player;
            numEnemies++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (numEnemies < maxNumEnemies)
        {
            GameObject currEnemy = Instantiate(enemy, transform.position, Quaternion.identity);
            currEnemy.GetComponent<enemyAI>().player = _player;
            numEnemies++;
        }
    }
}
