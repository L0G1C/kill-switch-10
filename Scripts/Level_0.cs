using Godot;
using System;
using System.Linq;

public class Level_0 : Node2D
{    
    public override void _Ready()
    {
        SceneManager.Instance.SceneSetup(this.GetType().Name);
    }

}
