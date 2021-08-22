using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement2D))] 
public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField] private Movement2D movement2D;
    void Start()
    {
        movement2D = GetComponent<Movement2D>();
    }

   
    void FixedUpdate()
    {
        float xAxis = Input.GetAxisRaw("Horizontal");
        float yAxis = Input.GetAxisRaw("Vertical");

        movement2D.Move(xAxis, yAxis, movement2D.Normalize);
    }
}
