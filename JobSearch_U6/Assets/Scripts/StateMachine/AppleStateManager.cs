using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleStateManager : MonoBehaviour
{
    public AppleBaseState currentState;
    public AppleGrowState growState = new AppleGrowState();
    public AppleStaticState staticState = new AppleStaticState();
    public AppleEatenState eatenState = new AppleEatenState();
    public Sprite appleEatenSprite;


    void Start()
    {
        currentState = growState;
        currentState.EnterState(this);
    }
    void Update()
    {
        currentState.OnUpdate(this);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        currentState.OnTriggerEnter(this, other);
    }

    public void SwitchState(AppleBaseState state)
    {
        currentState.ExitState(this);
        currentState = state;
        state.EnterState(this);
    }

    public void DestroyObj(float t)
    {
        Destroy(gameObject, t);
    }
}
