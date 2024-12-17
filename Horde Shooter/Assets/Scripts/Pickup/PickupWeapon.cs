using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupWeapon : Pickup
{
    public Weapon weaponToEquip;

    public override void OnTriggerEnter(Collider other)
    {
        //equip weapon
        if (weaponToEquip != null)
        {
            Pawn thePawn = other.GetComponent<Pawn>();
            if (thePawn != null)
            {
                thePawn.EquipWeapon(weaponToEquip);

            }
        }


        //do what all pickups do
        base.OnTriggerEnter(other);
    }

}
