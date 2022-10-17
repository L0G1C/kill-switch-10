using Godot;
using System;

public class SoundManager : Node
{
	private AudioStreamPlayer2D _AudioStreamPlayer;
	private AudioStreamPlayer MusicPlayer;

	// SFX
	private AudioStreamSample _footstep1 = (AudioStreamSample)GD.Load(@"res://Audio/SFX/Footstep.wav");
	private AudioStreamSample _footstep2 = (AudioStreamSample)GD.Load(@"res://Audio/SFX/Footstep2.wav");
	private AudioStreamSample _footstep3 = (AudioStreamSample)GD.Load(@"res://Audio/SFX/Footstep3.wav");
	private AudioStreamSample _footstep4 = (AudioStreamSample)GD.Load(@"res://Audio/SFX/Footstep4.wav");
	private AudioStreamSample _titleSlash = (AudioStreamSample)GD.Load(@"res://Audio/SFX/TitleSlash.wav");    
	private AudioStreamMP3 _Door = (AudioStreamMP3)GD.Load(@"res://Audio/SFX/Door.mp3");  

	// Music
	private AudioStreamSample _titleMusic = (AudioStreamSample)GD.Load(@"res://Audio/Music/Intro.wav");    
	private AudioStreamSample _levelMusic = (AudioStreamSample)GD.Load(@"res://Audio/Music/Level.wav");    
	private AudioStreamSample _encounterMusic = (AudioStreamSample)GD.Load(@"res://Audio/Music/Encounter.wav");    
	
	private RandomNumberGenerator _random;

	public static SoundManager Instance;

	public override void _Ready()
	{
		Instance = this;    
		_AudioStreamPlayer = GetNode<AudioStreamPlayer2D>("AudioStreamPlayer2D");
		MusicPlayer = GetNode<AudioStreamPlayer>("MusicPlayer");
		_random = new RandomNumberGenerator();
	}

	public void HandleStepEvent()
	{
		PlayStep();
	}

	public void PlayTitleSlash()
	{        
		_AudioStreamPlayer.Stream = _titleSlash;
		_AudioStreamPlayer.PitchScale = 1.5f;
		_AudioStreamPlayer.Play();
		_AudioStreamPlayer.PitchScale = 1;
	}

	public void PlayDoor()
	{
		_AudioStreamPlayer.Stream = _Door;
		_AudioStreamPlayer.VolumeDb = 1.5f;
		_AudioStreamPlayer.Play();
	}

	public void PlayTitleMusic()
	{           	
		MusicPlayer.Stream = _titleMusic;        
		MusicPlayer.Play();
	}

	public void PlayLevelMusic()
	{		
		MusicPlayer.Stream = _levelMusic;
		MusicPlayer.Play();
	}

	public void PlayEncounterMusic()
	{
		MusicPlayer.Stream = _encounterMusic;
		MusicPlayer.Play();
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
