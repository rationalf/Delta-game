using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyUpgradeWeapon : MonoBehaviour
{
    private float _cost = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private float _katanaDMGUP = 1.1f;
    public void KatanaDMGUP()
    {
        if (PlayerPrefs.GetFloat("credits") >= _cost)
        {
            PlayerPrefs.SetFloat("katanaDamage", PlayerPrefs.GetFloat("katanaDamage") * _katanaDMGUP);
            PlayerPrefs.SetFloat("credits", PlayerPrefs.GetFloat("credits")-_cost);
        }
    }
    
    private float _katanaResistCoef = 1.1f;
    public void KatanaResist()
    {
        if (PlayerPrefs.GetFloat("credits") >= _cost)
        {
            PlayerPrefs.SetFloat("damageResistance", PlayerPrefs.GetFloat("damageResistance")*_katanaResistCoef);
            PlayerPrefs.SetFloat("credits", PlayerPrefs.GetFloat("credits")-_cost);
        }
    }
    
    private float _pistolDMGUP = 1.1f;
    public void PistolDMGUP()
    {
        if (PlayerPrefs.GetFloat("credits") >= _cost)
        {
            PlayerPrefs.SetFloat("pistolDamage", PlayerPrefs.GetFloat("pistolDamage") * _pistolDMGUP);
            PlayerPrefs.SetFloat("credits", PlayerPrefs.GetFloat("credits")-_cost);
        }
    }
    
    private float _pistolBulletSpeedCoef = 1.1f;
    public void PistolBulletSpeed()
    {
        if (PlayerPrefs.GetFloat("credits") >= _cost)
        {
            PlayerPrefs.SetFloat("pistolBulletSpeed", PlayerPrefs.GetFloat("pistolBulletSpeed")*_pistolBulletSpeedCoef);
            PlayerPrefs.SetFloat("credits", PlayerPrefs.GetFloat("credits")-_cost);
        }
    }
    
    private float _railgunDMGUP = 1.1f;
    public void RailgunDMGUP()
    {
        if (PlayerPrefs.GetFloat("credits") >= _cost)
        {
            PlayerPrefs.SetFloat("railgunDamage", PlayerPrefs.GetFloat("railgunDamage") * _railgunDMGUP);
            PlayerPrefs.SetFloat("credits", PlayerPrefs.GetFloat("credits")-_cost);
        }
    }
    private float _railgunShotDelay = 1.1f;
    public void RailgunShotDelay()
    {
        if (PlayerPrefs.GetFloat("credits") >= _cost)
        {
            PlayerPrefs.SetFloat("railgunDamage", PlayerPrefs.GetFloat("railgunDamage") / _railgunShotDelay);
            PlayerPrefs.SetFloat("credits", PlayerPrefs.GetFloat("credits")-_cost);
        }
    }
}
