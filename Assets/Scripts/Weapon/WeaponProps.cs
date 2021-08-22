using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(order = 0,fileName = "New Weapon",menuName = "Weapons/Weapon")]
public class WeaponProps : ScriptableObject
{

    public float shootDamage = 10f;

    public Vector2 shootDirection;

    public float fireRate = .3f;


}
