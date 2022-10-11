using Godot;
using System;
using System.Collections.Generic;

public class NotBackedUpState : BaseState
{
    public override void OnUpdate()
    {
        base.OnUpdate();
        // Doesn't really do anything but just testing
        StateMachine.Instance.ChangeState("NotBackedUpState");
    }
}
