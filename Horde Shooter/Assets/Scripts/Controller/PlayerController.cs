using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller
{
    public bool isMouseRotation;
    public float sprintTime;

    // Start is called before the first frame update
    protected override void Start()
    {

    }

    // Update is called once per frame
    protected override void Update()
    {
        //anything the humanoid controller does on update

        //do what every controller does
        base.Update();


    }

    protected override void MakeDecisions()
    {
        //move our pawn based on input axes
        Vector3 moveVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        //limit vector for controller players
        moveVector = Vector3.ClampMagnitude(moveVector, 1);

        //tell pawn to move
        if (Input.GetAxis("Sprint") > 0 && sprintTime > 0)
        {
            pawn.Sprint(moveVector);
            //Debug.Log("I AM SPRINTING");
            sprintTime -= 1;
        }
        else
        {
            pawn.Move(moveVector);
            //Debug.Log("I am walking");
            while (sprintTime < 1000 && Input.GetAxis("Sprint") <1)
            {
                sprintTime += 1;
            }
        }

        Debug.Log(sprintTime);

        if(isMouseRotation)
        {
            //create the ray from mouse position in the direciotn the camera is facing
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            //create a plane at our feet, and a normal (perpendicular direction) of world up
            Plane footPlane = new Plane(Vector3.up, pawn.transform.position);

            //find the distance down that ray that the plane and ray intersect
            float distanceToIntersect;

            //out calls do not need to be initialized as long as they are assigned a value before return
            if (footPlane.Raycast(mouseRay, out distanceToIntersect))
            {
                //find intersection point
                Vector3 intersectionPoint = mouseRay.GetPoint(distanceToIntersect);

                //look at intersection point
                pawn.RotateToLookAt(intersectionPoint);

            }
            else
            {
                Debug.Log("Camera not looking at ground, no intersection between plane and ray.");
            }
        }
        else
        {
            //tell pawn to rotate on cameraRotation axis
            pawn.Rotate(Input.GetAxis("Camera Rotation"));
        }

        //Debug.Log(Input.GetAxis("Sprint"));
        
    }
    
    
    
 
}

