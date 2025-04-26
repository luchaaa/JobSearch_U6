using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCombatCooldownState : PlayerCombatBaseState
{
    public float totalCooldown;
    public float currentCooldown;

    public static UnityAction cooldownOver;

    public override void EnterState(PlayerCombatManager stateManager){
        currentCooldown = 0;
        Debug.Log("attack in cooldown.");
    }  

    public override void OnUpdate(PlayerCombatManager stateManager){ 
        if (currentCooldown >= totalCooldown){
            cooldownOver();
            return;
        } 
        currentCooldown += Time.deltaTime;
        float ratio = currentCooldown / totalCooldown;
        //Debug.Log(ratio);
        
    }  

    public override void ExitState(PlayerCombatManager stateManager){

    }
}
