using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    private Animator anim;

    private float xAxis;

    private string currentState;
    
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    
    void SteerAnim(float x)
    {
        anim.SetFloat(AnimatorProperties.s_steerProp,x);
    }

    public void ChangeAnimationStates(string newState)
    {
        if(currentState == newState)
            return;
        
        //toca a animação
        anim.Play(newState);
        
        //reatribui o estado atual da animação
        currentState = newState;
    }
   
}
