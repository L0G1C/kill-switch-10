using Godot;
using System;
using System.Collections.Generic;

public class DefaultState : BaseState
{
    public override void OnStart(Dictionary<string, object> data)
    {
        GetNode<CanvasLayer>("HUD").Visible = true;
        GetNode<TextureRect>("HUD/PanelContainer/VBoxContainer/HBoxContainer/BackupIcon").Visible = false;        
    }

    public override void OnExit(string exitState)
	{
        GetNode<CanvasLayer>("HUD").Visible = false;
    }
}
