using Godot;
using System;

public class Door : Node2D
{
	[Export]
	public Texture DoorTexture {get; set;}

	public override void _Ready()
	{
		var spriteNode = GetNode<Sprite>("Sprite");

		if (DoorTexture != null)
			spriteNode.Texture = DoorTexture;
	}

	public override void _Process(float delta)
	{
		
	}

	public void PlayDoorSound()
	{
		SoundManager.Instance.PlayDoor();
	}
}
