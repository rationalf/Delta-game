using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSS : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 direction;
    public Animator anim;
    void Start()
    {   
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
}
