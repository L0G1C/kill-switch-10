using Godot;
using System;
using System.Collections.Generic;

public class BackedUpState : BaseState
{
    public override void OnStart(Dictionary<string, object> data)
    {
        base.OnStart(data);

        EmitSignal("backedUp", StateMachine.Instance.IsBackedUp);

    }
    public override void UpdateState(float delta)
    {
        StateMachine.Instance.IsBackedUp = true;
        
    }

    public override void _Ready()
    {
        base._Ready();
    }
}
