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

    public void LoadLevel(string levelName)
    {
        UnloadLevel();
        var levelPath = $"res://Scenes/{levelName}.tscn";
        var levelResource = (PackedScene)GD.Load(levelPath);

        if (levelResource != null)
        {
            _levelInstance = levelResource.Instance();
            GetTree().ChangeSceneTo(levelResource);
        }
    }
}
