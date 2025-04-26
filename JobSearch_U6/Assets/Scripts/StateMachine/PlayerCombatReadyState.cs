using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatReadyState : PlayerCombatBaseState
{
    public override void EnterState(PlayerCombatManager stateManager){
        Debug.Log("attack now ready!");
    }  

    public override void OnUpdate(PlayerCombatManager stateManager){  

    }  

    public override void ExitState(PlayerCombatManager stateManager){
        Debug.Log("attack going on cooldown.");
    }
}
