using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    public WeaponProps weaponProperties;
    
    public Transform shootPoint; 
    public string bulletTagPrefab;
    
    public abstract void Shoot();
}
