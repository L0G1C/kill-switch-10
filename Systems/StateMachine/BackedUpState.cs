using Godot;
using System;
using System.Collections.Generic;

public class BackedUpState : BaseState
{
    public override void OnStart(Dictionary<string, object> data)
    {
        GetNode<CanvasLayer>("HUD").Visible = true;
        GetNode<TextureRect>("HUD/PanelContainer/VBoxContainer/HBoxContainer/BackupIcon").Visible = true;        
    }
}
