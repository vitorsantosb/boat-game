using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateObject : MonoBehaviour
{
    [SerializeField] private bool useCountdown;
    [SerializeField] private float countDown = 3f;
    
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

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
    //Countdown com um delay antes da função ser chamada
    IEnumerator CountDown(float delay)
    {
        yield return new WaitForSeconds(delay);
        countDown -= Time.deltaTime;
        if (countDown <= 0)
        {
            countDown = countAux;
            gameObject.SetActive(false);
        }
    }
    void Update()
    {
        if(useCountdown)
            CountDown();
    }
}
