using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateStuff;

public class SCR_WanderState : State<SCR_EnemyBehavior>
{
    private static SCR_WanderState instance;

    private SCR_WanderState()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }
    public static SCR_WanderState Instance
    {
        get
        {
            if (instance == null)
            {
                new SCR_WanderState();
            }
            return instance;
        }
    }
    public override void EnterState(SCR_EnemyBehavior owner)
    {
        if (owner.wanderTime > 0)
        {
            owner.transform.Translate(Vector3.forward * owner.moveSpeed);
            owner.wanderTime -= Time.deltaTime;
        }

    }

    public override void ExitState(SCR_EnemyBehavior owner)
    {
    }

    public override void UpdateState(SCR_EnemyBehavior owner)
    {
        if(owner.isPlayerSpotted)
        {
            //owner.stateMachine.ChangeState(SCR_ChaseState.Instance);
        }
            owner.Wander();
    }
}
