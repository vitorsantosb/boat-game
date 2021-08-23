using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingScript : MonoBehaviour
{
    [Range(1f,6f)]
    [SerializeField] private float scrollSpeed = 2f;

    [SerializeField] private float resetDistance = 20f;
    //Direção do scrolling
    [SerializeField] private Vector2 scrollDir = Vector2.up;
    
    private Vector2 startPos;
    void Start()
    {
        startPos = transform.position;
    }

    void Scrolling()
    {
        float newPos = Mathf.Repeat(scrollSpeed * Time.time, resetDistance);
        transform.position = startPos + scrollDir * newPos;
    }
    void Update()
    {
        Scrolling();
    }
}
