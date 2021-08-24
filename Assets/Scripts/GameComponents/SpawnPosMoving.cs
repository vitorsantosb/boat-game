using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPosMoving : MonoBehaviour
{
    [SerializeField] private Movement2D movement2D;
    
    [Range(.5f,5f)]
    [SerializeField] private float amplitude = 2f;
    void Start()
    {
        movement2D = GetComponent<Movement2D>();
    }

    
    void Update()
    {
        movement2D.SineWaveMove(new Vector2(-1,1), amplitude, false);
    }
}
