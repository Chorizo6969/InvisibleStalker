using UnityEngine;

public class AI_FollowPlayerState : AI_BaseState
{
    public override void OnEnter()
    {
        Debug.Log("Entering FollowPlayer State");
    }

    public override void Update()
    {
        if (StateMachine.Sensor.PlayerNear)
        {
            TransitionToMenacing();
            return;
        }

        StateMachine.Controller.MoveTo(StateMachine.Player.transform.position);
    }

    public override void OnExit()
    {
        Debug.Log("Exiting FollowPlayer State");
    }
}
