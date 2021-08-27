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

    void CacheDeath()
    {
        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<PlayerShootingScript>().enabled = false;
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
                    CacheDeath();
                    print("Morri");
                    //call interface
                    
                    //testa o player morrendo, já fiz a função
                    isDead = true;
                    break;
                case "Enemy":
                    anim.ChangeAnimationStates("Enemy" + AnimatorProperties.s_Death);
                    playerScore += 300;
                    
                    Destroy(gameObject, 2f);
                    print("Inimigo animação toca");
                    
                    break;
            }
        }
    }

    private float time = 5f;
    public void CallEndGame()
    {
        if (isDead)
        {
            print("OTO MORRENDO AAAAAAAAAA");
            StartCoroutine(GameManager.FinishGame(time, GameManager.InterfaceGaymeOver));
            isDead = false;
        }
    
    }
    

    private void Update()
    {
        CallEndGame();
    }
}
