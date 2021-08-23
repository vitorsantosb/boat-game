using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour ,IHit
{
    /*TROCAR PARA UM SCRIPT DE DANO GERAL DEPOIS*/
    [SerializeField] int HP = 50;

    private int myHp;

    private void Start()
    {
        myHp = HP;
    }

    public void DamageHit(float dmg)
    {
        myHp -= (int)dmg;
        Debug.Log($"Received {dmg} of damage ",this.gameObject);
        if (myHp <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    
}
