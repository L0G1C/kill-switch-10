using Godot;
using System;

public class SceneManager : Control
{
    private Node _levelInstance;
    public Node _main2D;
    public static SceneManager Instance;

    public override void _Ready()
    {
        Instance = this;
    }

    public void UnloadLevel()
    {
        if (IsInstanceValid(_levelInstance))
            _levelInstance.QueueFree();
        _levelInstance = null;
    }

    internal void LoadEncounterLevel()
    {
        UnloadLevel();
        var levelPath = $"res://Scenes/Encounter.tscn"; // TODO - Randomly Generate Encounter name
        var levelResource = (PackedScene)GD.Load(levelPath);

        if (levelResource != null)
        {
            _levelInstance = levelResource.Instance();
            GetTree().ChangeSceneTo(levelResource);
            //GetTree().Root.AddChild(_levelInstance);            
        }            
    }

    public void LoadLevel(string levelName)
    {
        UnloadLevel();
        var levelPath = $"res://Scenes/{levelName}.tscn";
        var levelResource = (PackedScene)GD.Load(levelPath);

        if (levelResource != null)
        {
            _levelInstance = levelResource.Instance();
            GetTree().ChangeSceneTo(levelResource);
            //GetTree().Root.AddChild(_levelInstance);            
        }                                
    }

    public void ScemeSetup(string levelName)
    {
        // Setup Signal Connections            
        var player = GetNode<Node>($"/root/{levelName}/Player");
        var StateMachine = GetNode<Node>("/root/StateMachine");            
        var SoundManager = GetNode<Node>("/root/SoundManager");

        player.Connect("BackupEvent", StateMachine, "HandleBackedUpEvent");
        player.Connect("StepEvent", SoundManager, "HandleStepEvent");
    }
}
