using Godot;
using System;

public class SoundManager : Node
{
    private 

    public SoundManager Instance;

    public override void _Ready()
    {
        Instance = this;    
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
