using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameActionSpawnParticles : GameAction
{
    public GameObject particlePrefab;
    public float lifespan;
    public Transform targetNode;

    public void SpawnParticles()
    {
        //instantiate object at target node
        GameObject particles = Instantiate(particlePrefab, targetNode.position, targetNode.rotation);

        //if a lifespan is added, set to destroy after delay
        if(lifespan > 0)
        {
            Destroy(particles,lifespan);
        }


    }


}
