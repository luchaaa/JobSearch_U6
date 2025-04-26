using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleGrowState : AppleBaseState
{
    // Start is called before the first frame update

    public override void EnterState(AppleStateManager stateManager)
    {

    }

    public override void OnUpdate(AppleStateManager stateManager)
    {
        stateManager.gameObject.transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);
        if (stateManager.gameObject.transform.localScale.x > 5)
        {
            stateManager.SwitchState(stateManager.staticState);
        }
    }

    public override void OnTriggerEnter(AppleStateManager stateManager, Collider2D collider)
    {

    }

    public override void ExitState(AppleStateManager stateManager)
    {

    }
}

