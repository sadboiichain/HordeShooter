using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pawn : MonoBehaviour
{
    //variables
    public Controller controller;
    public float maxMoveSpeed;
    public float maxRotationSpeed;

    //methods to override
    public abstract void Move(Vector3 direction);
    public abstract void Sprint(Vector3 direction);
    public abstract void Rotate(float speed);
    public abstract void RotateToLookAt(Vector3 targetPoint);
}
