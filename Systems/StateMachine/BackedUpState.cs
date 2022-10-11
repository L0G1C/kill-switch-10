using Godot;
using System;
using System.Collections.Generic;

public class BackedUpState : BaseState
{
     public void HandleBackedUpEvent()
    {
        GD.Print("Handling BackedUpState Event!");
        GD.Print("Current State: " + StateMachine.Instance.CurrentState);
        StateMachine.Instance.ChangeState("BackedUpState");
        GD.Print("New State: " + StateMachine.Instance.CurrentState);
    }
}
