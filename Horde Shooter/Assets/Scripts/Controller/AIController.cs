using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : Controller
{
    //variables for the pawn
    [HideInInspector] public NavMeshAgent agent;
    public float stoppingDistance;
    public Transform targetTransform;
    private Vector3 desiredVelocity = Vector3.zero;

    // Start is called before the first frame update
    protected override void Start()
    {
        //everything the base does
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    protected override void MakeDecisions()
    {
        // break early if no pawn is found
        if (pawn == null)
        {
            Debug.Log("NO Pawn Found, ended early.");
            return;
        }

        // start finding target
        agent.SetDestination(targetTransform.position);

        // get speed needed to follow path
        desiredVelocity = agent.desiredVelocity;

        // make the pawn move towards player
        pawn.Move(desiredVelocity.normalized);

        // Look towards the player
        pawn.RotateToLookAt(targetTransform.position);
    }

    public override void PosessPawn(Pawn pawnToPosess)
    {
        //everything from base controller
        base.PosessPawn(pawnToPosess);

        //get nav mesh from pawn
        agent = pawn.GetComponent<NavMeshAgent>();

        //if agent is not found, make one
        if (agent == null)
        {
            agent = pawn.gameObject.AddComponent<NavMeshAgent>();
        }

        // Set the stopping distance
        agent.stoppingDistance = stoppingDistance;

        // Set the max speed of the AI from the pawn data
        agent.speed = pawn.maxMoveSpeed;

        // Set the max rotation speed of the AI from the pawn data
        agent.angularSpeed = pawn.maxRotationSpeed;

        // Disable movement and rotation from the NavMeshAgent
        agent.updatePosition = false;
        agent.updateRotation = false;
    }

    public override void unpossessPawn()
    {
        // Remove the NavMeshAgent
        Destroy(agent);

        // do what the base does
        base.unpossessPawn();
    }


}
