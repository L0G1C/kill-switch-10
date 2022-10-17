using Godot;
using System;

public class SplashIntro : Control
{
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
