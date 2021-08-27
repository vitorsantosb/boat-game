using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Damage : MonoBehaviour ,IHit
{
    /*TROCAR PARA UM SCRIPT DE DANO GERAL DEPOIS*/
    [SerializeField] int HP = 50;

    private int myHp;

    private bool isDead;
    
    public static double playerScore;
    
    private AnimationManager anim;
    private void Start()
    {
        myHp = HP;
        anim = GetComponent<AnimationManager>();
    }

    private void OnDisable()
    {
        ResetLife();
    }

    void ResetLife()
    {
        myHp = HP;
    }
    
    float t = 2f;
    public void DamageHit(float dmg)
    {
        myHp -= (int)dmg;
        //Debug.Log($"Received {dmg} of damage ",this.gameObject);
        
        if (myHp <= 0 && this.gameObject != null)
        {
            switch (gameObject.tag)
            {
                case "Player":
                    anim.ChangeAnimationStates("Player" + AnimatorProperties.s_Death);
                    GetComponent<PlayerMovement>().enabled = false;
                    print("Morri");
                    isDead = true;
                    break;
                case "Enemy":
                    anim.ChangeAnimationStates("Enemy" + AnimatorProperties.s_Death);
                    playerScore += 300;
                    
                    Destroy(gameObject, 2f);
                    print("Inimigo animação toca");
                    isDead = true;
                    break;
            }
        }
    }
    
    
   
}
