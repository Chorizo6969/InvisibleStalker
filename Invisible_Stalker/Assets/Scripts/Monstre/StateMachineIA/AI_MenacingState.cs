using System;
using UnityEngine;

public class AI_MenacingState : AI_BaseState
{
    private float _menacingTimer = 0f;
    private float _menacingDuration = 5f;

    public override void OnEnter()
    {
        Debug.Log("Entering Menacing State");
        StateMachine.Controller.StopMoving();
        StateMachine.Source.clip = StateMachine.Clip15s;
        StateMachine.Source.Play();
    }

    public override void Update()
    {
        _menacingTimer += Time.deltaTime;

        if (_menacingTimer >= _menacingDuration)
        {
            TransitionToKillPlayer();
        }

        if (!StateMachine.Sensor.PlayerNear)
        {
            TransitionToFollow();
        }
    }

    public override void OnExit()
    {
        Debug.Log("Exiting Menacing State");
        StateMachine.Source.Stop();
        _menacingTimer = 0f;
    }
}
