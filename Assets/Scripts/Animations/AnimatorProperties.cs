using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AnimatorProperties
{
    //Inteiros
    public static readonly int i_Idle = Animator.StringToHash("Idle");
    
    public static readonly int i_steerProp = Animator.StringToHash("Steer");

    public static readonly int i_Death = Animator.StringToHash("Death");

    //Strings
    public static readonly string s_Idle = "Idle";

    public static readonly string s_steerProp = "Steer";

    public static readonly string s_Death = "Death";
    
    //Krack

    public static readonly string s_KrakenTrap = "KrakenAtack";

}
