using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyParameters : MonoBehaviour
{
    private float _cost = 10f;

    private float _hpUp = 1.05f;
    public void hpUP()
    {
        if (PlayerPrefs.GetFloat("credits") >= _cost)
        {
            PlayerPrefs.SetFloat("maxHealth", PlayerPrefs.GetFloat("maxHealth")*_hpUp);
            PlayerPrefs.SetFloat("health", PlayerPrefs.GetFloat("maxHealth"));
            PlayerPrefs.SetFloat("credits", PlayerPrefs.GetFloat("credits") - _cost);
        }
    }

    private float _damageUP = 1.05f;
    public void dmgUP()
    {
        if (PlayerPrefs.GetFloat("credits") >= _cost)
        {
            PlayerPrefs.SetFloat("katanaDamage", PlayerPrefs.GetFloat("katanaDamage") * _damageUP);
            PlayerPrefs.SetFloat("pistolDamage", PlayerPrefs.GetFloat("pistolDamage") * _damageUP);
            PlayerPrefs.SetFloat("railgunDamage", PlayerPrefs.GetFloat("railgunDamage") * _damageUP);
            PlayerPrefs.SetFloat("credits", PlayerPrefs.GetFloat("credits")-_cost);
        }
    }

    private float _incomeUP = 1f;
    public void incomeUP()
    {
        if (PlayerPrefs.GetFloat("credits") >= _cost)
        {
            PlayerPrefs.SetFloat("income", PlayerPrefs.GetFloat("income")+_incomeUP);
            PlayerPrefs.SetFloat("credits", PlayerPrefs.GetFloat("credits") - _cost);

        }
    }
}
