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

    public int quantDeBandeiras = 0;
    
    public List<GameObject> barcos = new List<GameObject>();
    
    private AnimationManager anim;

    private float cooldown = 1.5f;
    private float coolDownAux;

    private float oldSpeed;
    
    private void Start()
    {
        dmg = GetComponent<Damage>();
        movement2D = GetComponent<PlayerMovement>();
        anim = GetComponent<AnimationManager>();
        
        coolDownAux = cooldown;
        oldSpeed = movement2D.GetPlayerMove().GetSpeed;
    }
    
    void Snare()
    {
        movement2D.GetPlayerMove().GetMyRigidBody2D().constraints = RigidbodyConstraints2D.FreezeAll;
        movement2D.GetPlayerMove().SetSpeed(0f);
        movement2D.enabled = false;
        HabilitarBarcos(false,0f);
        
        cooldown -= Time.deltaTime;
        if (cooldown <= 0)
        {
            print("KrakenRealizado");
            movement2D.enabled = true;
            movement2D.GetPlayerMove().GetMyRigidBody2D().constraints = RigidbodyConstraints2D.FreezeRotation;
            movement2D.GetPlayerMove().SetSpeed(oldSpeed);
            HabilitarBarcos(true,6);
            
            cooldown = coolDownAux;
            startSnare = false;
        }
    }
    
    void HabilitarBarcos(bool habilita, float vel)
    {
        foreach (GameObject canoaMove in barcos)
        {
            PlayerMovement can = canoaMove.GetComponent<PlayerMovement>();
            
            can.GetPlayerMove().GetMyRigidBody2D().constraints = RigidbodyConstraints2D.FreezeAll;
            can.GetPlayerMove().SetSpeed(vel);
            can.enabled = habilita;
        }
    }
   
    private bool maxSpawnsReached;
    public int board_count;
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

            if (!maxSpawnsReached)
            {
                if (board_count < 4)
                {
                    GameObject obj = Pooling.Instance.SpawnFromPool("Canoa", playerSpawns[board_count].position,
                        Quaternion.identity);
                    obj.transform.SetParent(transform);
                    barcos.Add(obj);
                    UpdateBandeiras();
                    obj.gameObject.SetActive(true);
                    board_count++;
                    //Debug.Log("Barco adicionado a lista - contagem de barcos atual: " + barcos.Count);

                }
                else if (board_count > 4)
                {
                    maxSpawnsReached = true;
                }
            }
            else
            {
                maxSpawnsReached = false;
                board_count--;
            }
            // 1- Adicionar um barco!
            // 2- Adicionar o barco a lista
            // 3- Torna o barca filho do player
            // 4- Adicionar a contagem de barcos após pega uma moeda
            // 5- e reseta sempre que perde um barco

        }
        
        if (other.gameObject.CompareTag("Kraken"))
        {
            startSnare = true;
            anim.ChangeAnimationStates(AnimatorProperties.s_KrakenTrap);
            Destroy(other.gameObject);
        }
    }

    

    public void UpdateBandeiras()
    {
        quantDeBandeiras++;
        if (quantDeBandeiras < 5)
        {
            for (int i = 0; i < quantDeBandeiras; i++)
            {
                bandeiras[i].GetComponent<SpriteChange>().ChangeSprite();
            }
        }
    }
    private void Update()
    {
        if (startSnare)
        {
            Snare();
        }
    }
}
