using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyBoat : EnemyBase 
{
    /*movement = para mover o Inimigo de uma certaManeira*/
    private int myHp;
    private float gunFireRate;

    [Header("ENEMY MOVEMENT")] 
    
    [SerializeField] private float steerFreq = .1f; 
    
    [SerializeField] float steerAmp = 1f;

    public float SetSteerAmplitude(float m_SteerAmp) => steerAmp = m_SteerAmp;
    
    private void Start()
    {
        gunFireRate = enemyWeapon.fireRate;
        myHp = enemyType.HP;
        movement = GetComponent<Movement2D>();
    }

    public override void Move()
    {
        movement.Move(new Vector2(Mathf.Sin(Time.time + steerFreq) * steerAmp,-movement.GetSpeed),true);
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
    // public void DamageHit(float dmg)
    // {
    //     myHp -= (int)dmg;
    //     print($"Received {dmg} amounts of damage");
    //     if (myHp <= 0)
    //     {
    //         gameObject.SetActive(false);
    //     }
    // }

    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        EnemyShoot();
    }
}
