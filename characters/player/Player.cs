using Godot;
using System;

public class Player : Area2D
{
	[Export]
	public int Speed = 400; // How fast the player will move (pixels/sec).

	public Vector2 ScreenSize; // Size of the game window.

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		ScreenSize = GetViewportRect().Size;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		var velocity = Vector2.Zero; // The player's movement vector.

		if (Input.IsActionPressed("move_right"))
		{
			velocity.x += 1;
		}

		if (Input.IsActionPressed("move_left"))
		{
			velocity.x -= 1;
		}

		if (Input.IsActionPressed("move_down"))
		{
			velocity.y += 1;
		}

		if (Input.IsActionPressed("move_up"))
		{
			velocity.y -= 1;
		}

		if (velocity.Length() > 0)
		{
			velocity = velocity.Normalized() * Speed;
		}
		
		Position += velocity * delta;
		Position = new Vector2(
			x: Mathf.Clamp(Position.x, 0, ScreenSize.x),
			y: Mathf.Clamp(Position.y, 0, ScreenSize.y)
		);
	}
}
