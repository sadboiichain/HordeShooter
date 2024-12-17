using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//require a health component
[RequireComponent(typeof(Health))]
public class Death_Destroy : MonoBehaviour
{
    [SerializeField] private float delayBeforeDestruction;


    // Start is called before the first frame update
    void Start()
    {
        //get health component
        Health health = GetComponent<Health>();

        //register listener with the onDie event
        health.onDeath.AddListener(destroyOnDeath);
    }

    // Update is called once per frame
    private void destroyOnDeath()
    {
        Destroy(gameObject, delayBeforeDestruction);
    }
}
