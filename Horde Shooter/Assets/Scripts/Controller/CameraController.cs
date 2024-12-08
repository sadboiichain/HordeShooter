using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float distance;


    // Update is called once per frame
    void Update()
    {
        //calculate camera location
        Vector3 newPosition = new Vector3(target.position.x, target.position.y + distance, target.position.z);

        //move to position
        transform.position = Vector3.MoveTowards(transform.position, newPosition, speed * Time.deltaTime);

        //look at target
        transform.LookAt(target.position, target.forward);

    }
}
