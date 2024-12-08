using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanoidPawn : Pawn
{
    private Animator animator;
    public bool useLocalDirections;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //movement
    public override void Move(Vector3 direction)
    {
        //apply speed to the direction by multiplying max speed?
        direction = direction * maxMoveSpeed;

        //I DONT KNOW WHY THIS EXISTS, BUT ITS IN THE LESSONS
        if(useLocalDirections)
        {
        //Change direction from world to local space
        direction = transform.InverseTransformDirection(direction);
        }

        //send values from controller to animator
        animator.SetFloat("Forward", direction.z);
        animator.SetFloat("Right", direction.x);

        //Change direction from world to local space
        direction = transform.InverseTransformDirection(direction);
    }

    public override void Sprint(Vector3 direction)
    {
        float SprintMoveSpeed = maxMoveSpeed * 2;

        //apply speed to the direction by multiplying max speed?
        direction = direction * SprintMoveSpeed;

        //I DONT KNOW WHY THIS EXISTS, BUT ITS IN THE LESSONS
        if (useLocalDirections)
        {
            //Change direction from world to local space
            direction = transform.InverseTransformDirection(direction);
        }

        //send values from controller to animator
        animator.SetFloat("Forward", direction.z);
        animator.SetFloat("Right", direction.x);

        //Change direction from world to local space
        direction = transform.InverseTransformDirection(direction);

       
    }    

    //rotation
    public override void Rotate(float speed)
    {
        //use the function to rotate based on speed
        transform.Rotate(0, speed * maxRotationSpeed * Time.deltaTime, 0);
    }

    //look at mouse
    public override void RotateToLookAt(Vector3 targetpoint)
    {
        //find the vector from current location to target point
        Vector3 lookVector = targetpoint - transform.position;

        //find rotation that will look down at vector with world up being up direction
        Quaternion lookRotation = Quaternion.LookRotation(lookVector, Vector3.up);

        //rotate towards target rotation slowly
        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, maxRotationSpeed * Time.deltaTime);
    }

    //when animation movement happens
    public void OnAnimatorMove()
    {
        //after anim happens, use root motion to move game object
        transform.position = animator.rootPosition;
        transform.rotation = animator.rootRotation;

        //if navMeshAgent is on controller
        AIController aiController = controller as AIController;
        if (aiController != null)
        {
            //set nav mesh to understand it as position from the animator?
            aiController.agent.nextPosition = animator.rootPosition;
        }

    }


}
