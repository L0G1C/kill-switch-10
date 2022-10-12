using Godot;
using System;
using System.Linq;
using System.Collections.Generic;

public class BaseStateMachine : Node
{
	// Events that can be used for all states
	[Signal]
	public delegate void PreStart();
	[Signal]
	public delegate void PostStart();
	[Signal]
	public delegate void PreExit();
	[Signal]
	public delegate void PostExit();

	public List<BaseState> States;
	public string CurrentState;
	public string LastState;
	protected BaseState _state = null;

	public override void _Ready()
	{
		base._Ready();			
		PrintTree()	;
		States = GetNode<Node>("States").GetChildren().OfType<BaseState>().ToList();
	}

	// Privately sets the current state of the StateMachine. If there is an existing state
	// calls the OnExit Method for it to emit its ExitState signal
	private void SetState(BaseState newState, Dictionary<string, object> data)
	{
		if (newState == null)
			return;
		if (_state != null)
		{
			EmitSignal(nameof(PreExit));
			_state.OnExit(_state.GetType().ToString());
			EmitSignal(nameof(PostExit));
		}

		LastState = CurrentState;
		GD.Print($"Last State: {LastState}");
		CurrentState = newState.GetType().ToString();
		GD.Print($"Current State: {CurrentState}");

		_state = newState;
		EmitSignal(nameof(PreStart));
		_state.OnStart(data);
		EmitSignal(nameof(PostStart));
		_state.OnUpdate();
	}

	/// optional <data> attribute to send with event.
	public void ChangeState(string stateName, Dictionary<string, object> data = null)
	{
		foreach (BaseState state in States)
		{			
			if (stateName == state.GetType().ToString())
			{
				SetState(state, data);
				return;
			}
		}
	}

	public override void _PhysicsProcess(float delta)
	{
		if (_state == null)
			return;
		
		_state.UpdateState(delta);
	}
	
}
