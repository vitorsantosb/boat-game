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

    public int GetMyHP() => myHp;
    
    private bool isDead;
    
    public static float playerScore = 300;

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
        GetComponent<CapsuleCollider2D>().enabled = false;
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
                    
                    GameManager.EnableOrDisableGameObject(false, GameObject.FindWithTag("ScoreCanvas"));
                    //testa o player morrendo, já fiz a função
                    isDead = true;
                    break;
                
                case "MiniPlayer":
                    anim.ChangeAnimationStates("Canoa" + AnimatorProperties.s_Death);
                    CacheDeath();
                    print("Canoa Morreu");
                    
                    Destroy(gameObject, 1f);
                    break;
                case "Enemy":
                    anim.ChangeAnimationStates("Enemy" + AnimatorProperties.s_Death);
                    gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
                    StartCoroutine((GameManager.Score(playerScore)));
                    Destroy(gameObject, 1.8f);
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
            StartCoroutine(GameManager.FinishGame(time, GameManager.InterfaceGaymeOver));
            isDead = false;
        }
    
    }
    

    private void Update()
    {
        CallEndGame();
    }
}
