using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    public EnemyProps enemyType;
    public WeaponProps enemyWeapon;
    
    public Transform enemyShootPoint;
    
    public Movement2D movement;
    
    public abstract void Move();
    public abstract void DoAttack();
}
