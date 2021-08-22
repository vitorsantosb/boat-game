using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoat : EnemyBase , IHit
{
    /*movement = para mover o Inimigo de uma certaManeira*/
    private int myHp;
    private float gunFireRate;
    private void Start()
    {
        gunFireRate = enemyWeapon.fireRate;
        myHp = enemyType.HP;
        movement = GetComponent<Movement2D>();
    }

    public override void Move()
    {
        
    }
    
    public override void DoAttack()
    {
        GameObject obj = Pooling.Instance.SpawnFromPool("EnemyCanon", enemyShootPoint.position, Quaternion.identity);
    }
    void ResetWeaponSettings()
    {
        gunFireRate = enemyWeapon.fireRate;
    }
    
    void EnemyShoot()
    {
        gunFireRate -= Time.deltaTime;
        if (gunFireRate < 0)
        {
            DoAttack();
            ResetWeaponSettings();
        }
    }
    public void DamageHit(float dmg)
    {
        myHp -= (int)dmg;
        print($"Received {dmg} amounts of damage");
        if (myHp <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        EnemyShoot();
    }
}
