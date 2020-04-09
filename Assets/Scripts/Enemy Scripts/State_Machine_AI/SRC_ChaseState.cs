using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateStuff;

public class SCR_ChaseState : State<SCR_EnemyBehavior>
{
    private static SCR_ChaseState instance;

    private SCR_ChaseState()
    {
        if(instance != null)
        {
            return;
        }
        instance = this;
    }
    public static SCR_ChaseState Instance
    {
        get
        {
            if(instance == null)
            {
                new SCR_ChaseState();
            }
            return instance;
        }
    }
    public override void EnterState(SCR_EnemyBehavior owner)
    {
        //owner.transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
        //owner.transform.position += owner.transform.forward * owner.moveSpeed * Time.deltaTime;
    }

    public override void ExitState(SCR_EnemyBehavior owner)
    {
    }

    public override void UpdateState(SCR_EnemyBehavior owner)
    {
    }
}
