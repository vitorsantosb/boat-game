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
    private int numeroDeSpawns;

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
        numeroDeSpawns = spawmPos.Count;
        //StartCoroutine(SpawnEnemies(1f));
    }

    
    IEnumerator SpawnEnemies(float delay)
    {
        if (spawnStates == SpawnStates.SPAWNING)
        {
            for (int i = 0; i < numeroDeSpawns; i++)
            {
                GameObject obj = Pooling.Instance.SpawnFromPool("Inimigo",
                    spawmPos[Random.Range(i, numeroDeSpawns)].position,
                    spawmPos[Random.Range(i, numeroDeSpawns)].rotation);
                //reseta a gravidade dos inimigos, para evitar o acumulo da velocidade dos barcos
                obj.GetComponent<Rigidbody2D>().gravityScale = .1f;
                
                yield return new WaitForSeconds(delay);
            }

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
