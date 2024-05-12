using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossJumpAttack : MonoBehaviour
{ 
    // Start is called before the first frame update
    private int _damageAmount = 20;
    private float liveJump;
    [SerializeField] GameObject splash;
    private GameObject _splash;
    void Start()
    {
        liveJump = 0;
        StartCoroutine(FireCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        liveJump += Time.deltaTime;
        if (liveJump > 0.5f)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerStatistics>().TakeDamage(_damageAmount);
        }
    }
    private IEnumerator FireCoroutine()
    {
        _splash = Instantiate(splash, this.gameObject.transform.position, Quaternion.Euler(90,0,90)) as GameObject;
        _splash = Instantiate(splash, this.gameObject.transform.position, Quaternion.Euler(90,0,90)) as GameObject;
        _splash = Instantiate(splash, this.gameObject.transform.position, Quaternion.Euler(90,0,90)) as GameObject;
        yield return new WaitForSeconds(2);
        Destroy(_splash);
    }
}
