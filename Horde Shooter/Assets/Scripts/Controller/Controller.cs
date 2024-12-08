using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Controller : MonoBehaviour
{
    //variable to hold the pawn class
    public Pawn pawn;
    
    

    // Start is called before the first frame update
    protected virtual void Start()
    {
        //if pawn exists
        if (pawn != null)
        {
            //take control of it
            PosessPawn(pawn);
        }
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        //check for inputs every frame
        MakeDecisions();
    }

    //inputs and responses
    protected abstract void MakeDecisions();

    public virtual void PosessPawn(Pawn pawnToPosess)
    { 
        //set variable to the pawn that we want to posess
        pawn = pawnToPosess;

        //set pawn's controller to this controller
        pawn.controller = this; 

    }

    public virtual void unpossessPawn() 
    { 
        //set pawn's controller to null
        pawn.controller = null;

        //set pawn to null
        pawn = null;
    }



}
