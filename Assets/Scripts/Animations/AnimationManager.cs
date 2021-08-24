using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    private Animator anim;

    void Animation_Float(float x)
    {
        anim.SetFloat(AnimatorProperties.s_steerProp,x);
    }
}
