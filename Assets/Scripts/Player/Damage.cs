using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour ,IHit
{
    /*TROCAR PARA UM SCRIPT DE DANO GERAL DEPOIS*/
    [SerializeField] int playerHP = 50;

    private int myHp;

    private void Start()
    {
        myHp = playerHP;
    }

    public void DamageHit(float dmg)
    {
        myHp -= (int)dmg;
        if (myHp <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    
}
