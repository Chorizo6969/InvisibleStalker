using UnityEngine;

public class AI_KillPlayerState : AI_BaseState
{
    public override void OnEnter()
    {
        Debug.Log("Player Killed");
        // anim jumpscare
    }

    public override void Update()
    {
        // tkt
    }

    public override void OnExit()
    {
        Debug.Log("Exiting KillPlayer State");
    }
}
