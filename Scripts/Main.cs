using Godot;
using System;
using System.Linq;

public class Main : Control
{	
	public override void _Ready()
	{		
		// TODO - Not currenlty needed unless we change SceneManager's "ChangeScene" at load level.
		SceneManager.Instance._main2D = GetNode<Node>("Main2D");
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
}
