using Godot;
using System;

public class Player : KinematicBody2D
{
 private Vector2 velocity = Vector2.Zero;	
	 const float ACCELERATION = 450;
	 const float MAX_SPEED = 100;
	 const float FRICTION = 450;

	 private AnimationTree _animTree;
	 private AnimationNodeStateMachinePlayback _animState;

	public override void _Ready()
	{		
	}

	public override void _PhysicsProcess(float delta)
	{
		var inputVector = Vector2.Zero;
		_animTree = GetNode<AnimationTree>("AnimationTree");
		_animState = (AnimationNodeStateMachinePlayback)_animTree.Get("parameters/playback");

		inputVector.x = Input.GetActionStrength("right") - Input.GetActionStrength("left");
		inputVector.y = Input.GetActionStrength("down") - Input.GetActionStrength("up");

		inputVector = inputVector.Normalized(); //trim vector to normalized length

		if (inputVector != Vector2.Zero)	
		{	
			_animTree.Set("parameters/Idle/blend_position", inputVector);
			_animTree.Set("parameters/Walk/blend_position", inputVector);
			_animState.Travel("Walk");
			velocity = velocity.MoveToward(inputVector * MAX_SPEED, ACCELERATION * delta);			
		}
		else
		{
			velocity = velocity.MoveToward(Vector2.Zero, FRICTION * delta);		
			_animState.Travel("Idle");
		}

		velocity = MoveAndSlide(velocity);
	}
}
