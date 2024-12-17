using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
    //variables across all weapons
    public float damageDone;
    public float fireRate;

    //for IK rigging
    public Transform RightHandIKTarget;
    public Transform LeftHandIKTarget;

    //set up for child classes
    [Header("Events")]
    public UnityEvent OnPrimaryAttackBegin;
    public UnityEvent OnPrimaryAttackEnd;
    public UnityEvent OnSecondaryAttackBegin;
    public UnityEvent OnSecondaryAttackEnd;


}
