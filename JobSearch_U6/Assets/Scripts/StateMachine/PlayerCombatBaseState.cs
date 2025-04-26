using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerCombatBaseState
{
    public abstract void EnterState(PlayerCombatManager stateManager);
    public abstract void ExitState(PlayerCombatManager stateManager);
    public abstract void OnUpdate(PlayerCombatManager stateManager);
}
