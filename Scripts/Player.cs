using Godot;
using System;

public class Player : KinematicBody2D
{
 private Vector2 velocity = Vector2.Zero;	
	 const float ACCELERATION = 450;
	 const float MAX_SPEED = 100;
	 const float FRICTION = 450;
	 
	 [Signal]
	 public delegate void BackupEvent();

	[Signal]
	 public delegate void StepEvent();

	 private AnimationTree _animTree;
	 private AnimationNodeStateMachinePlayback _animState;
	 private bool _openingDoor = false;

	public override void _Ready()
	{		
		_animTree = GetNode<AnimationTree>("AnimationTree");
		_animState = (AnimationNodeStateMachinePlayback)_animTree.Get("parameters/playback");

		_animTree.Active = true;
	}

	public override async void _PhysicsProcess(float delta)
	{
		if(_openingDoor)
			return;
		
		var inputVector = Vector2.Zero;
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

		for (int i = 0; i < GetSlideCount(); i++)
		{
			var collision = GetSlideCollision(i);

			// Freeze P, play animations and load next level
			if (((Node)collision.Collider).IsInGroup("Doors"))
			{
				
				_openingDoor = true;
				_animTree.Active = false;
				GetNode<Timer>("Camera2D/CanvasLayer/TimerLabel/Timer").Paused = true;
				var doorAnim = GetNode<AnimationPlayer>("../TileMap/Door/AnimationPlayer"); //Todo change to signal
				doorAnim.Play("Open");
				await ToSignal(doorAnim, "animation_finished");

				var playerDoorAnim = GetNode<AnimationPlayer>("AnimationPlayer");
				playerDoorAnim.Play("OpenDoor");
				await ToSignal(playerDoorAnim, "animation_finished");

				var prefix = "Level_";
				var currentLevel = GetParent().Name;
				var levelIndex = currentLevel.Substring(currentLevel.LastIndexOf('_') + 1);
				
				if (StateMachine.Instance.CurrentState == nameof(DefaultState))
					EmitSignal(nameof(BackupEvent));
					
				SceneManager.Instance.LoadLevel(prefix + (Convert.ToInt32(levelIndex) + 1).ToString());
			}
				
		}
	}

	public void StepTrigger()
	{
		EmitSignal(nameof(StepEvent));
	}
}
