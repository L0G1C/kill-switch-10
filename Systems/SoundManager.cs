using Godot;
using System;

public class SoundManager : Node
{
    private AudioStreamPlayer2D _AudioStreamPlayer;
    private AudioStreamSample _footstep1 = (AudioStreamSample)GD.Load(@"res://Audio/SFX/Footstep.wav");
    private AudioStreamSample _footstep2 = (AudioStreamSample)GD.Load(@"res://Audio/SFX/Footstep2.wav");
    private AudioStreamSample _footstep3 = (AudioStreamSample)GD.Load(@"res://Audio/SFX/Footstep3.wav");
    private AudioStreamSample _footstep4 = (AudioStreamSample)GD.Load(@"res://Audio/SFX/Footstep4.wav");
    private RandomNumberGenerator _random;

    public SoundManager Instance;

    public override void _Ready()
    {
        Instance = this;    
        _AudioStreamPlayer = GetNode<AudioStreamPlayer2D>("AudioStreamPlayer2D");
        _random = new RandomNumberGenerator();
    }

    public void HandleStepEvent()
    {
        PlayStep();
    }

    private void PlayStep()
    {
        var randomInt = _random.RandiRange(1, 4);        

        switch (randomInt)
        {
            case 1:
                _AudioStreamPlayer.Stream = _footstep1;
            break;
            case 2:
                _AudioStreamPlayer.Stream = _footstep2;
            break;
            case 3:
                _AudioStreamPlayer.Stream = _footstep3;
            break;
            case 4:
                _AudioStreamPlayer.Stream = _footstep4;
            break;
        }

        _AudioStreamPlayer.VolumeDb = -5.5f;
        _AudioStreamPlayer.Play();
    }


}
