using UnityEngine;

public abstract class AI_BaseState
{
    public AI_StateMachine StateMachine;

    public abstract void OnEnter();
    public abstract void Update();
    public abstract void OnExit();

    protected void EnterChase()
    {
        Debug.Log("Chase");
        //StateMachine.TransitionTo(StateMachine.ChaseState);
    }

    protected void EnterMenacing()
    {
        Debug.Log("Menacing");
    }

    protected void EnterFlashing()
    {
        Debug.Log("Flashing");
    }

    protected void EnterFollowing()
    {
        Debug.Log("following");
    }

    protected void EnterKilling()
    {
        Debug.Log("Killing");
    }
}
