using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionManager : MonoBehaviour
{
    private Damage dmg;

    private void Start()
    {
        dmg = GetComponent<Damage>();
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            dmg.DamageHit(10f);
            other.gameObject.GetComponent<Damage>().DamageHit(20f);
        }
    }
}
