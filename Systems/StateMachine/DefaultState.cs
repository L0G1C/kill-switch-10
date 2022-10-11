using Godot;
using System;
using System.Collections.Generic;

public class DefaultState : BaseState
{
     public void HandleDefaultEvent()
    {
        GD.Print("Handling DefaultState Event!");
        GD.Print("Current State: " + StateMachine.Instance.CurrentState);
        StateMachine.Instance.ChangeState("DefaultState");
        GD.Print("New State: " + StateMachine.Instance.CurrentState);
    }
}
