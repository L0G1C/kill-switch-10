using Godot;
using System;

public class Level_0 : Node2D
{
    // TODO - Move this to SceneManager.LoadLevel()
    public override void _Ready()
    {
        var player = GetNode<Node>("Player");
        var SM = GetNode<Node>("StateMachine");

        player.Connect("BackupEvent", SM, "HandleBackedUpEvent");
    }

}
