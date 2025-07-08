using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerStats : MonoBehaviour
{
    public int cost = 10;
    public int rangeBase = 10;
    public float damageBase = 10;
    private BaseAffects baseAffects;
    public int rangeFinal = 10;
    private float damageFinal = 10;

    //Setting the variables needed in this script

    void Start()
    {

        baseAffects = gameObject.transform.parent.GetComponentInParent<BaseAffects>();
        rangeFinal = baseAffects.rangeBonus + rangeBase;
        damageFinal = baseAffects.damageMult * damageBase;
        //gets the final variables to be correct after the multipliers from the towers
    }

}
