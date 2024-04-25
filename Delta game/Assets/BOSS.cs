using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BOSS : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 direction;
    public Animator anim;
    private float hp;
    private int maxHealth = 3000;
    private int damage = 75;
    void Start()
    {   
        hp = maxHealth;
        anim.SetTrigger("go");
        // Set initial direction (random)
        direction = Vector3.forward;
        transform.position += direction * speed * Time.deltaTime;
    }

    void Update()
    {   
        anim.SetTrigger("go");
        // Move the ball
        if (transform.position.x <= -25f || transform.position.x >= 25f || transform.position.z <= -25f || transform.position.z >= 25f)
        {
            anim.SetTrigger("close");
            speed = 0f;
            direction = this.transform.forward;
            transform.position -= direction * 0.5f;
            Invoke("ResumeMovement", 1f);
        }
        else
        {
            direction = this.transform.forward;
            transform.position += direction * speed * Time.deltaTime;
        }
    }
    void ResumeMovement()
    {   
        direction = this.transform.forward;
        transform.position -= direction * 0.5f;
        // Resume movement
        this.transform.eulerAngles = this.transform.eulerAngles + new Vector3(0, 125, 0);
        speed = 5f;
    }

    private IEnumerator Stop()
    {
        speed = 0;
        yield return new WaitForSeconds(10f);
    }
    public void TakeDamage(float damageAmount)
    {
        hp -= damageAmount;

        if (hp <= 0)
        {
            StartCoroutine(Die());
        }
        print(hp);
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerStatistics>().TakeDamage(damage);
        }
    }
}
