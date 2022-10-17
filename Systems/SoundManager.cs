using Godot;
using System;

public class SoundManager : Node
{
    private AudioStreamPlayer2D _AudioStreamPlayer;
    private AudioStreamPlayer _TitleMusicPlayer;
    private AudioStreamSample _footstep1 = (AudioStreamSample)GD.Load(@"res://Audio/SFX/Footstep.wav");
    private AudioStreamSample _footstep2 = (AudioStreamSample)GD.Load(@"res://Audio/SFX/Footstep2.wav");
    private AudioStreamSample _footstep3 = (AudioStreamSample)GD.Load(@"res://Audio/SFX/Footstep3.wav");
    private AudioStreamSample _footstep4 = (AudioStreamSample)GD.Load(@"res://Audio/SFX/Footstep4.wav");
    private AudioStreamSample _titleSlash = (AudioStreamSample)GD.Load(@"res://Audio/SFX/TitleSlash.wav");    
    
    private RandomNumberGenerator _random;

    public static SoundManager Instance;

    public override void _Ready()
    {
        Instance = this;    
        _AudioStreamPlayer = GetNode<AudioStreamPlayer2D>("AudioStreamPlayer2D");
        _TitleMusicPlayer = GetNode<AudioStreamPlayer>("TitleMusicPlayer");
        _random = new RandomNumberGenerator();
    }

    public void HandleStepEvent()
    {
        PlayStep();
    }

    public void HandleTitleSlash()
    {        
        _AudioStreamPlayer.Stream = _titleSlash;
        _AudioStreamPlayer.PitchScale = 1.5f;
        _AudioStreamPlayer.Play();
        _AudioStreamPlayer.PitchScale = 1;
    }

    public void PlayTitleMusic()
    {           
        _TitleMusicPlayer.Play();
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
