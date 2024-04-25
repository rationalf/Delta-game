using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    private float _health = 100;
    public Animator anim;
    public Slider healthBar;
    

    // Update is called once per frame
    void Update()
    {
        healthBar.value = _health;
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
        anim.SetTrigger("death");
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 20);
        foreach (Collider hitCollider in hitColliders)
        {
            Vector3 hitPosition = hitCollider.transform.position;
            hitPosition.y = transform.position.y;
            hitCollider.SendMessage("CreditsIncrement", SendMessageOptions.DontRequireReceiver);
        }
        GetComponent<Collider>().enabled = false;
        healthBar.gameObject.SetActive(false);
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }
    
}
