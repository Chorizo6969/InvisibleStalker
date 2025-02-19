using UnityEngine;

public class AI_StateMachine : MonoBehaviour
{
    public Ai_Sensor Sensor;
    public AI_Controller Controller;
    public AudioSource Source;
    public AudioClip Clip15s;

    public AI_BaseState CurrentState { get; private set; }
    public AI_FollowPlayerState FollowPlayerState;
    public AI_MenacingState MenacingState;
    public AI_FlashingState FlashingState;
    public AI_KillPlayerState KillPlayerState;

    public GameObject Player;

    private void Start()
    {
        FollowPlayerState = new AI_FollowPlayerState { StateMachine = this };
        MenacingState = new AI_MenacingState { StateMachine = this };
        FlashingState = new AI_FlashingState { StateMachine = this };
        KillPlayerState = new AI_KillPlayerState { StateMachine = this };

        TransitionTo(FollowPlayerState); // Initial state
    }

    public void TransitionTo(AI_BaseState newState)
    {
        if (CurrentState != null)
        {
            CurrentState.OnExit();
        }

        CurrentState = newState;
        CurrentState.OnEnter();
    }

    private void Update()
    {
        if (CurrentState != null)
        {
            CurrentState.Update();
        }
    }
}
