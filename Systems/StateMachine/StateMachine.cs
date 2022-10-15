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
    }    

    public void HandleDefaultEvent()
    {     
        StateMachine.Instance.ChangeState("DefaultState");     
    }

    public void HandleBackedUpEvent()
    {        
        StateMachine.Instance.ChangeState("BackedUpState");        
    }

    public void HandleEncounterEvent()
    {
        StateMachine.Instance.ChangeState("InEncounterState");
    }

}
