using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    public GameObject bullet;
    public Camera mainCam;
    public Transform spawner;
    public GameObject hand;
    public float shootForce;
    public float spread;

    void Start()
    {
        if (!PlayerPrefs.HasKey("pistolBulletSpeed"))
        {
            PlayerPrefs.SetFloat("pistolBulletSpeed", 12);
            shootForce = PlayerPrefs.GetFloat("pistolBulletSpeed");
        }
    }
    // Update is called once per frame
    void Update()
    {
        shootForce = PlayerPrefs.GetFloat("pistolBulletSpeed");
        if (hand.GetComponent<PickUpWeapon>().currentWeapon==null) return;
        if (Input.GetMouseButtonDown(0) && hand.GetComponent<PickUpWeapon>().currentWeapon.CompareTag("Weapon_Pistol"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Ray ray = mainCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        Vector3 targetPoint;
        targetPoint = ray.GetPoint(15);

        Vector3 dirWithoutSpread = targetPoint - spawner.position;

        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);
        Vector3 dirWithSpread = dirWithoutSpread + new Vector3(x, y, 0);

        GameObject currentBullet = Instantiate(bullet, spawner.position, Quaternion.identity);
        currentBullet.transform.forward = dirWithSpread.normalized;
        currentBullet.GetComponent<Rigidbody>().AddForce(dirWithSpread.normalized * shootForce, ForceMode.Impulse);
        
    }
}
