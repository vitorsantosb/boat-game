using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement2D))] 
public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField] private Movement2D movement2D;

    [SerializeField] private AnimationManager playerAnim;

    private bool steerRight;
    
    private string stateAdd = "Player";
    
    void Start()
    {
        movement2D = GetComponent<Movement2D>();
        playerAnim = GetComponent<AnimationManager>();
        
    }

    void SteerAnim(float x)
    {
        playerAnim.ChangeAnimationStates(x != 0 ? 
            "Player" + AnimatorProperties.s_steerProp : 
            "Player" + AnimatorProperties.s_Idle);

        if (x > 0 && !steerRight)
        {
            Flip();
        }
        else if(x < 0 && steerRight)
        {
             Flip();
        }
    }

    void Flip()
    { 
        steerRight = !steerRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    
    void FixedUpdate()
    {
        float xAxis = Input.GetAxisRaw("Horizontal");
        float yAxis = Input.GetAxisRaw("Vertical");
        
        SteerAnim(xAxis);
        
        movement2D.Move(xAxis, yAxis, movement2D.Normalize);
    }
}
