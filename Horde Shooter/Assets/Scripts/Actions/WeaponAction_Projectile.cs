using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAction_Projectile : WeaponAction
{
    public float damageDone;
    public float fireRate;

    private float lastShotTime;
    public Transform firepoint;
    public GameObject projectilePrefab;

    public void Shoot()
    {
        //check if weapon can fire again
        float secondsPerShot = 1 / weapon.fireRate;
        if (Time.time >= lastShotTime + secondsPerShot)
        {
            //if true, instantiate projectile
            GameObject projectile = Instantiate(projectilePrefab, firepoint.position, firepoint.rotation);

            //set layer of projectile
            projectile.gameObject.layer = this.gameObject.layer;

            //set data for projectile
            Projectile projectileData = projectile.GetComponent<Projectile>();

            //do the raycast
            if (projectileData != null)
            {
                projectileData.damage = weapon.damageDone;
            }
            //save time of successful shot
            lastShotTime = Time.time;
        }
    }
}
