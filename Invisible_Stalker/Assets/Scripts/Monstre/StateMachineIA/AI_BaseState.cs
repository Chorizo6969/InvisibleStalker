using UnityEngine;

public abstract class AI_BaseState
{
    public AI_StateMachine StateMachine;

    public abstract void OnEnter();
    public abstract void Update();
    public abstract void OnExit();

    protected void TransitionToFollow()
    {
        StateMachine.TransitionTo(StateMachine.FollowPlayerState);
    }

    protected void TransitionToMenacing()
    {
        StateMachine.TransitionTo(StateMachine.MenacingState);
    }

    protected void TransitionToKillPlayer()
    {
        StateMachine.TransitionTo(StateMachine.KillPlayerState);
    }

    protected void TransitionToFlashing()
    {
        StateMachine.TransitionTo(StateMachine.FlashingState);
    }
}
