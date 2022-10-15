using Godot;
using System;

public class Timer : Godot.Timer
{
    [Signal]
	 public delegate void EncounterEvent();
    public override void _Ready()
    {
        
    }

    public void OnTimerTimeout()
    {        
        EmitSignal(nameof(EncounterEvent));
        SceneManager.Instance.LoadEncounterLevel();
    }
}
