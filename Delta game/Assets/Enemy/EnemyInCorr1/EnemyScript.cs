using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    private int _health = 100;
    public Animator anim;
    public Slider healthBar;

    // Update is called once per frame
    void Update()
    {
        healthBar.value = _health;
    }

    public void TakeDamage(int damageAmount)
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
        GetComponent<Collider>().enabled = false;
        healthBar.gameObject.SetActive(false);
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }
    
}
