using Godot;
using System;
using System.Linq;

public class Main : Control
{	
	public override void _Ready()
	{				
	}

	public void OnPlayBtnPressed()
	{	
		// Load Initial Level
		SceneManager.Instance.LoadLevel("Level_0");

		// Setup StateMachine with Initial States
		// StateMachine/States node should have all states as children with BaseState class
		//StateMachine.Instance.States = GetNode<Node>("/root/StateMachine/States").GetChildren().OfType<BaseState>().ToList();
		StateMachine.Instance.ChangeState("DefaultState");
	}

	public void OnTitleAnimationComplete()
	{		
		SoundManager.Instance.PlayTitleSlash();
	}

	public void StartMusic()
	{
		SoundManager.Instance.PlayTitleMusic();
	}
}
