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
        ChangeState("DefaultState");
    }

}
