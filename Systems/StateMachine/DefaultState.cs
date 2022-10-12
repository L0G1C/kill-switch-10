using Godot;
using System;
using System.Collections.Generic;

public class DefaultState : BaseState
{
    public override void OnStart(Dictionary<string, object> data)
    {
        var backupIcon = GetNode<TextureRect>("HUD/PanelContainer/VBoxContainer/HBoxContainer/BackupIcon");
        backupIcon.Visible = false;
    }
}
