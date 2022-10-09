using Godot;
using System;

public class SceneManager : Control
{
    private Node _levelInstance;
    private Node _main2D;

    public override void _Ready()
    {
        _main2D = GetNode<Node>("Main2D");
    }

    public void UnloadLevel()
    {
        if (IsInstanceValid(_levelInstance))
            _levelInstance.QueueFree();
        _levelInstance = null;
    }

    public void LoadLevel(string levelName)
    {
        UnloadLevel();
        var levelPath = $"res://Scenes/{levelName}.tscn";
        var levelResource = (PackedScene)GD.Load(levelPath);

        if (levelResource != null)
        {
            _levelInstance = levelResource.Instance();
            _main2D.AddChild(_levelInstance);
        }
    }

    public void OnPlayBtnPressed()
    {
        LoadLevel("Level_0");
    }
}
