using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionManager : MonoBehaviour
{
    private Damage dmg;

    private PlayerMovement movement2D;
    private bool startSnare;
    
    private void Start()
    {
        dmg = GetComponent<Damage>();
        movement2D = GetComponent<PlayerMovement>();
    }
    
    void Snare(float cooldown)
    {
        cooldown -= Time.deltaTime;
        if (cooldown <= 0)
        {
            movement2D.enabled = false;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            dmg.DamageHit(10f);
            other.gameObject.GetComponent<Damage>().DamageHit(20f);
        }

        if (other.gameObject.CompareTag("Kraken"))
        {
            startSnare = true;
        }
    }

    private void Update()
    {
        if (startSnare)
        {
            Snare(2f);
        }
    }
}
