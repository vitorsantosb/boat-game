using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingScript : WeaponBase
{
    private float gunFireRate;
    private void Start()
    {
        gunFireRate = weaponProperties.fireRate;
    }

    public override void Shoot()
    {
        GameObject obj = Pooling.Instance.SpawnFromPool("Canon", shootPoint.position, Quaternion.identity);
    }

    IEnumerator Shooting(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        Shoot();
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
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Shooting();
            //StartCoroutine(Shooting(weaponProperties.fireRate));
        }
    }
}
