using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class Projectile : MonoBehaviour
{
    //variables
    public float damage;
    public float moveSpeed;
    public float lifespan;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        //get rigidbody component
        rb = GetComponent<Rigidbody>();

        //destroy when lifespan is up
        Destroy(gameObject, lifespan);
    }

    // Update is called once per frame
    void Update()
    {
        //move forward at movespeed (not per frame)
        rb.velocity = transform.forward * moveSpeed;
    }

    public void OnTriggerEnter(Collider other)
    {
        //get health component
        Health otherHealth = other.GetComponent<Health>();

        //if health component exists, take damage
        if (otherHealth != null)
        {
            otherHealth.TakeDamage(damage);

        }

        //destroy projectile
        Destroy(gameObject);

    }
}
