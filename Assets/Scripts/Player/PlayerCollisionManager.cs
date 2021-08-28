using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerCollisionManager : MonoBehaviour
{
    private Damage dmg;

    private PlayerMovement movement2D;
    private bool startSnare;
    
    [Header("Canoa Spawns")]
    public Transform[] playerSpawns; 
    public GameObject canoaPrefab;
    public GameObject[] bandeiras = new GameObject[4];
    
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

    private bool maxSpawnsReached;
    int i = 0;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            dmg.DamageHit(10f);
            other.gameObject.GetComponent<Damage>().DamageHit(20f);
        }

        if (other.gameObject.CompareTag("CoinPlayer"))
        {
            Destroy(other.gameObject);
            if (i < 4 && !maxSpawnsReached)
            {
                GameObject obj = Instantiate(canoaPrefab, playerSpawns[i].position, Quaternion.identity);
                obj.transform.SetParent(transform);
                i++;
            }
            else if (i > 4)
            {
                i = 0;
                //i = 1
                bandeiras[i - 1].GetComponent<SpriteChange>().ChangeSprite();
                maxSpawnsReached = true;
            }
            


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
