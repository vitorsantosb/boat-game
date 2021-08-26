using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour ,IHit
{
    /*TROCAR PARA UM SCRIPT DE DANO GERAL DEPOIS*/
    [SerializeField] int HP = 50;

    private int myHp;

    private bool isDead;
    
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
        Debug.Log($"Received {dmg} of damage ",this.gameObject);
        
        if (myHp <= 0)
        {
            switch (gameObject.tag)
            {
                case "Player":
                    anim.ChangeAnimationStates("Player" + AnimatorProperties.s_Death);
                    isDead = true;
                    break;
                case "Enemy":
                    anim.ChangeAnimationStates("Enemy" + AnimatorProperties.s_Death);
                    isDead = true;
                    break;
            }

           
        }
    }

    private void Update()
    {
        if (isDead)
        {
            t -= Time.deltaTime;
            if (t <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
