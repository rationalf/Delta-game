using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript2 : MonoBehaviour
{
    private float _health = 100;
    

    // Update is called once per frame
    void Update()
    {
    }

    public void TakeDamage(float damageAmount)
    {
        _health -= damageAmount;

        if (_health <= 0)
        {
            StartCoroutine(Die());
        }
    }

    private IEnumerator Die()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 20);
        foreach (Collider hitCollider in hitColliders)
        {
            Vector3 hitPosition = hitCollider.transform.position;
            hitPosition.y = transform.position.y;
            hitCollider.SendMessage("CreditsIncrement", SendMessageOptions.DontRequireReceiver);
        }
        GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }
    
}