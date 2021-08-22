using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement2D))]
public class BulletMovement : MonoBehaviour
{
    [SerializeField] private Movement2D movement2D;
    private float speedAux;
    void Start()
    {
        movement2D = GetComponent<Movement2D>();
        
        speedAux = movement2D.GetSpeed;
    }

    void MovingForward(float slowRatio)
    {
        movement2D.Move(Vector2.up * (speedAux * slowRatio), false);
    }
    void FixedUpdate()
    {
        MovingForward(.3f);
    }
}
