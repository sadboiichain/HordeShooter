using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Weapon))]
public class WeaponAction : GameAction
{
    //to meet the requirement
    protected Weapon weapon;

    public override void Awake()
    {
        weapon = GetComponent<Weapon>();
        base.Awake();   
    }

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }
}
