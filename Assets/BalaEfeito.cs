using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaEfeito : MonoBehaviour
{
    private float countDown = 0.1f;

    private float countAux;
    void Start()
    {
        countAux = countDown;
    }
    void CountDown()
    {
        countDown -= Time.deltaTime;
        if (countDown <= 0)
        {
            countDown = countAux;
            Destroy(gameObject,11f);
        }
    }
    void Update()
    {
        CountDown();
    }
}
