using Godot;
using System;
using System.Collections.Generic;

public class BaseState : Node
{
private bool HasBeenInitialized = false;
	private bool OnUpdateHasFired = false;

	[Signal]
	public delegate void StateStart();
	[Signal]
	public delegate void StateUpdate();
	[Signal]
	public delegate void StateExit();
	
	public virtual void OnStart(Dictionary<string, object> data)
	{
		EmitSignal(nameof(StateStart));
		HasBeenInitialized = true;
	}

	public virtual void OnUpdate()
	{
		if (!HasBeenInitialized)
			return;
		
		EmitSignal(nameof(StateUpdate));
		OnUpdateHasFired = true;
	}

	public virtual void UpdateState(float dt)
	{
		if (!HasBeenInitialized)
			return;
	}

	public virtual void OnExit(string exitState)
	{
		if (!HasBeenInitialized)
			return;
		
		EmitSignal(nameof(StateExit));
		HasBeenInitialized = false;
		OnUpdateHasFired = false;
	}
}
