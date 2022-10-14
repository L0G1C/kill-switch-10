using Godot;
using System;

public class SoundManager : Node
{
    private AudioStreamPlayer2D _AudioStreamPlayer;

    public SoundManager Instance;

    public override void _Ready()
    {
        Instance = this;    
        _AudioStreamPlayer = GetNode<AudioStreamPlayer2D>("AudioStreamPlayer2D");
    }

    public void HandleStepEvent()
    {
        PlayStep();
    }

    private void PlayStep()
    {
        GD.Print("Step!");
    }


}
