using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KrakenMovement : MonoBehaviour
{
    private Movement2D movement;
    void Start()
    {
        movement = GetComponent<Movement2D>();
    }
    
    void FixedUpdate()
    {
        movement.Move(Vector2.down, true);
    }

   
}
