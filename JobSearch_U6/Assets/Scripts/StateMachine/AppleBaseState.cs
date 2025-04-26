using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class AppleBaseState
{
    public abstract void EnterState(AppleStateManager stateManager);
    public abstract void OnUpdate(AppleStateManager stateManager);
    public abstract void OnTriggerEnter(AppleStateManager stateManager, Collider2D collider2D);
    public abstract void ExitState(AppleStateManager stateManager);

}
