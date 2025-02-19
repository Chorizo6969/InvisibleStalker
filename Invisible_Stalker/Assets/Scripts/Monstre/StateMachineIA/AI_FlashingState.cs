using UnityEngine;

public class AI_FlashingState : AI_BaseState
{
    private float _respawnTimer = 0f;
    private float _respawnDuration = 30f;

    public override void OnEnter()
    {
        Debug.Log("Entering Flashing State");
        StateMachine.Controller.StopMoving();
    }

    public override void Update()
    {
        _respawnTimer += Time.deltaTime;

        if (_respawnTimer >= _respawnDuration)
        {
            TransitionToFollow();
        }
    }

    public override void OnExit()
    {
        Debug.Log("Exiting Flashing State");
        _respawnTimer = 0f;
    }
}
