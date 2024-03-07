using System.Collections;
using System.Collections.Generic;
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
            anim.SetTrigger("death");
            GetComponent<Collider>().enabled = false;
            healthBar.gameObject.SetActive(false);
        }
    }
}
