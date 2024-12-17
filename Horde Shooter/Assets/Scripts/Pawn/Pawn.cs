using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pawn : MonoBehaviour
{
    //access to other classes
    public Controller controller;
    public Weapon weapon;


    //variables
    public float maxMoveSpeed;
    public float maxRotationSpeed;
    public Transform weaponAttachmentPoint;

//methods to override
public abstract void Move(Vector3 direction);
    public abstract void Sprint(Vector3 direction);
    public abstract void Rotate(float speed);
    public abstract void RotateToLookAt(Vector3 targetPoint);

    //un/equip weapons using IK
    public void EquipWeapon(Weapon weaponToEquip)
    {
        //remove any weapon currently equipped
        unequipWeapon();

        //create the weapon as a child of the weapon attachment point with same values and save as player weapon
        Debug.Log(weaponToEquip + " " + weaponAttachmentPoint);

        weapon = Instantiate(weaponToEquip, weaponAttachmentPoint) as Weapon;

        //set weapon layer to match pawn
        weapon.gameObject.layer = this.gameObject.layer;
    }

    public void unequipWeapon()
    {
        //destroy weapon object
        if (weapon != null)
        {
            Destroy(weapon.gameObject);
        }
        
        //set weapon to null as insurance
        weapon = null;
    }



}
