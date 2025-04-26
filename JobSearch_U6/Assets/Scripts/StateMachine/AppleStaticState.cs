using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AppleStaticState : AppleBaseState
{
    // Start is called before the first frame update

    public override void EnterState(AppleStateManager stateManager)
    {
        stateManager.gameObject.transform.DOLocalMoveY(0.5f, 0.5f).SetRelative(true).SetLoops(-1, LoopType.Yoyo);
    }

    public override void OnUpdate(AppleStateManager stateManager)
    {

    }

    public override void OnTriggerEnter(AppleStateManager stateManager, Collider2D collider)
    {
        stateManager.SwitchState(stateManager.eatenState);
    }

    public override void ExitState(AppleStateManager stateManager)
    {

    }
}
