using UnityEngine;

public class AI_StateMachine : MonoBehaviour
{
    public AI_Sensor Sensor;
    public AI_Controller Controller;

    public AI_BaseState CurrentState { get; private set; }

    public AI_MenacingState MenacingState;
    public AI_FlashingState FlashingState;
    public AI_FollowPlayerState FollowPlayerState;
    public AI_KillPlayerState KillPlayerState;

    private void Start()
    {
        KillPlayerState = new AI_KillPlayerState();
        //KillPlayerState.StateMachine = this;

        MenacingState = new AI_MenacingState();
        //MenacingState.StateMachine = this;


        FlashingState = new AI_FlashingState();
        //FlashingState.StateMachine = this;

        FollowPlayerState = new AI_FollowPlayerState();
        //FollowPlayerState.StateMachine = this;

        //TransitionTo(FollowPlayerState);
    }

    public void TransitionTo(AI_BaseState state)
    {
        if (CurrentState != null)
        {
            if (state == CurrentState) return;
            CurrentState.OnExit();
        }

        CurrentState = state;
        CurrentState.OnEnter();
    }

    private void Update()
    {
        CurrentState.Update();
    }
}
