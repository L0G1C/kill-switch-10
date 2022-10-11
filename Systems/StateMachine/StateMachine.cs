using Godot;
using System;

public class StateMachine : BaseStateMachine
{
    public static StateMachine Instance;

    public bool IsBackedUp = false;

    public override void _Ready()
    {
        base._Ready();
        
        Instance = this;
        ChangeState("NotBackedUp");
    }

    public void HandleBackedUpEvent()
    {
        GD.Print("Handling BackedUp Event!");
        GD.Print("Current State: " + CurrentState);
        ChangeState("BackedUpState");
    }
}
