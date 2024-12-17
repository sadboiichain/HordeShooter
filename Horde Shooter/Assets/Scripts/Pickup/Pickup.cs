using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

//need a collider
[RequireComponent(typeof(Collider))]
public class Pickup : MonoBehaviour
{
    //collider to use
    private Collider colliderComponent;
    //event to make
    public UnityEvent onPickup;

    //asap
    public void Awake()
    {
        //load collider
        colliderComponent = GetComponent<Collider>();

        //set it to be a trigger
        colliderComponent.isTrigger = true;
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        //destroy pickup
        Destroy(gameObject);

        //invoke event to allow game actions
        onPickup.Invoke();
        
    }

}
