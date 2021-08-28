using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniPlayerShooting : WeaponBase
{
    private float gunFireRate;
    void Start()
    {
        gunFireRate = weaponProperties.fireRate;
    }
    
    public override void Shoot()
    {
        GameObject obj = Pooling.Instance.SpawnFromPool("MiniCanon", shootPoint.position, Quaternion.identity);
    }
    
    void Shooting()
    {
        gunFireRate -= Time.deltaTime;
        if (gunFireRate < 0)
        {
            Shoot();
            ResetWeaponSettings();
        }
    }

    void ResetWeaponSettings()
    {
        gunFireRate = weaponProperties.fireRate;
    }
    
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Shooting();
            //StartCoroutine(Shooting(weaponProperties.fireRate));
        }
    }
}
