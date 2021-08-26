using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public enum SpawnStates
{
    SPAWNING,
    WAITING
}
public class SpawnManager : MonoBehaviour
{
    [SerializeField] private int numeroDeSpawns;

    [SerializeField] private SpawnStates spawnStates;
    
    [SerializeField] private List<Transform> spawmPos;

    //[SerializeField] private float timeUpdateInterval = 2.5f;

    [SerializeField] private float countdown = 2.5f;
    
    private float countAux;
    void Start()
    {
        spawnStates = SpawnStates.WAITING;
        //timeUpdateInterval = (int) Time.fixedTime + 1;
        countAux = countdown;
        
    }

    
    IEnumerator SpawnEnemies(float delay)
    {
        if (spawnStates == SpawnStates.SPAWNING)
        {
            for (int i = 0; i < numeroDeSpawns; i++)
            {
                GameObject obj = Pooling.Instance.SpawnFromPool("Inimigo",
                    spawmPos[Random.Range(i, spawmPos.Count - 1)].position,
                    spawmPos[Random.Range(i, spawmPos.Count - 1)].rotation);
                
                //reseta a gravidade dos inimigos, para evitar o acumulo da velocidade dos barcos
                obj.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,Random.Range(-.5f,0.5f));
                obj.GetComponent<Rigidbody2D>().gravityScale = .05f + Random.Range(0f,.2f);
                obj.GetComponent<Movement2D>().SetSpeed(Random.Range(4f, 10f));
                obj.GetComponent<EnemyBoat>().SetSteerAmplitude(Random.Range(1, 10));
                
                yield return new WaitForSeconds(1f/ delay);
            }
            print("!");
            spawnStates = SpawnStates.WAITING;
        }

    }

    void Countdown()
    {
        if (spawnStates == SpawnStates.WAITING)
        {
            countdown -= Time.deltaTime;
            if (countdown <= 0)
            {
                spawnStates = SpawnStates.SPAWNING;
                StartCoroutine(SpawnEnemies(.86f));
                countdown = Random.Range(.8f ,countAux);
            }
        }
    }
    // void CustomUpdate()
    // {
    //     if (Time.fixedTime >= timeUpdateInterval)
    //     {
    //         StartCoroutine(SpawnEnemies(1f));
    //         
    //         timeUpdateInterval = (int) Time.fixedTime + 1;
    //     }
    // }

    private void Update()
    {
        Countdown();
    }
}
