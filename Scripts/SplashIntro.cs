using Godot;
using System;

public class SplashIntro : Control
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

	public override void _Input(InputEvent inputEvent)
	{
		if (inputEvent.IsActionPressed("ui_accept"))
		{
			SceneManager.Instance.LoadLevel("Main");
		}
	}

	public void IntroEnd()
	{
		SceneManager.Instance.LoadLevel("Main");
	}

}
