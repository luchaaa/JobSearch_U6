using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class AppleEatenState : AppleBaseState
{

    // Start is called before the first frame update
    public override void EnterState(AppleStateManager stateManager)
    {
        DOTween.Clear();
        stateManager.GetComponent<SpriteRenderer>().sprite = stateManager.appleEatenSprite;
        stateManager.DestroyObj(2);
    }

    public override void OnUpdate(AppleStateManager stateManager)
    {

    }

    public override void OnTriggerEnter(AppleStateManager stateManager, Collider2D collider)
    {

    }

    public override void ExitState(AppleStateManager stateManager)
    {

    }


}
