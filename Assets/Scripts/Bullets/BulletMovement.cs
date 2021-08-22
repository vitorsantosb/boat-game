using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement2D))]
public class BulletMovement : MonoBehaviour
{
    [SerializeField] private Movement2D movement2D;

    [SerializeField] private Vector2 bulletTrajectory = Vector2.up;
    
    private float speedAux;
    void Start()
    {
        movement2D = GetComponent<Movement2D>();
        
        speedAux = movement2D.GetSpeed;
    }

    void Moving(float slowRatio)
    {
        movement2D.Move(bulletTrajectory * (speedAux * slowRatio), false);
    }
    void FixedUpdate()
    {
        Moving(.3f);
    }
}
