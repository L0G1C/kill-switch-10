using Godot;
using System;

public class TimerLabel : Label
{
    private Timer _levelTimer;
    private Timer _waitTimer;
    private bool _levelTimerStarted;
    
    public override void _Ready()
    {
        base._Ready();

        Text = "10.00";

        _levelTimer = GetNode<Timer>("Timer");
        _waitTimer = new Timer();
        _waitTimer.WaitTime = 1;
        _waitTimer.OneShot = true;
        AddChild(_waitTimer);
        _waitTimer.Start();
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
 public override void _Process(float delta)
 {    
    if(_waitTimer.TimeLeft == 0 && !_levelTimerStarted)
    {
        _levelTimer.Start();
        _levelTimerStarted = true;
    }
    
    if (_levelTimerStarted)
        Text =_levelTimer.TimeLeft.ToString("n2");
 }
}
