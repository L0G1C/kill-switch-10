using Godot;
using System;

public class Player : KinematicBody2D
{
 private Vector2 velocity = Vector2.Zero;	
	 const float ACCELERATION = 450;
	 const float MAX_SPEED = 100;
	 const float FRICTION = 450;

	public override void _Ready()
	{		
		GD.Print("Ready!");
	}

	public override void _PhysicsProcess(float delta)
	{
		var inputVector = Vector2.Zero;
		inputVector.x = Input.GetActionStrength("right") - Input.GetActionStrength("left");
		inputVector.y = Input.GetActionStrength("down") - Input.GetActionStrength("up");

		inputVector = inputVector.Normalized(); //trim vector to normalized length

		if (inputVector != Vector2.Zero)		
			velocity = velocity.MoveToward(inputVector * MAX_SPEED, ACCELERATION * delta);			
		else
			velocity = velocity.MoveToward(Vector2.Zero, FRICTION * delta);		

		velocity = MoveAndSlide(velocity);
	}
}
