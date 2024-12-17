using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAction_Raygun : WeaponAction
{
    //variables for raycast shooting
    public float fireDistance;
    public Transform firepoint;
    public LineRenderer prefab;

    //other variables for firing
    private bool isAutofireActive;
    private LineRenderer lineRenderer;
    private float lastShotTime;

    public override void Awake()
    {
        base.Awake();
    }

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        if (isAutofireActive)
        {
            Shoot();

        }
    }

    public void Shoot()
    {
        //create variable to hold hit data
        RaycastHit hit;

        //check if weapon can fire again
        float secondsPerShot = 1/weapon.fireRate;
        if (Time.time >= lastShotTime + secondsPerShot)
        {
            //do the raycast
            if (Physics.Raycast(firepoint.position, firepoint.forward, out hit, fireDistance))
            {
                //grab health component from object hit
                Health otherHealth = hit.collider.GetComponent<Health>();

                Instantiate(prefab,firepoint);

                //if health component exists
                if (otherHealth != null)
                {
                    //tell it to take damage
                    otherHealth.TakeDamage(weapon.damageDone);
                }
            }
            //save time of successful shot
            lastShotTime = Time.time;
        }
    }

    public void AutoFireBegin()
    {
        isAutofireActive = true;
    }

    public void AutoFireEnd()
    {
        isAutofireActive = false;
    }

}
