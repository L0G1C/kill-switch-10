using Godot;
using System;
using System.Collections.Generic;

public class InEncounterState : BaseState
{
    public override void OnStart(Dictionary<string, object> data)
    {
        GetNode<CanvasLayer>("HUD").Visible = true;            
    }

    public override void OnExit(string exitState)
	{
        GetNode<CanvasLayer>("HUD").Visible = false;
    }
}
