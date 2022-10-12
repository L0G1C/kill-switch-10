using Godot;
using System;
using System.Collections.Generic;

public class DefaultState : BaseState
{
     public override void _Ready()
    {
        var backupIcon = GetNode<TextureRect>("HUD/PanelContainer/VBoxContainer/HBoxContainer/BackupIcon");
        backupIcon.Visible = false;
    }
}
