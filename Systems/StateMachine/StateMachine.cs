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

        if (String.IsNullOrEmpty(StateMachine.Instance.CurrentState))  
            ChangeState("DefaultState");
    }

    public void HandleDefaultEvent()
    {
        GD.Print("Handling DefaultState Event!");
        GD.Print("Current State: " + StateMachine.Instance.CurrentState);
        StateMachine.Instance.ChangeState("DefaultState");
        GD.Print("New State: " + StateMachine.Instance.CurrentState);
    }

    public void HandleBackedUpEvent()
    {
        GD.Print("Handling BackedUpState Event!");
        GD.Print("Current State: " + StateMachine.Instance.CurrentState);
        StateMachine.Instance.ChangeState("BackedUpState");
        GD.Print("New State: " + StateMachine.Instance.CurrentState);
    }

}
