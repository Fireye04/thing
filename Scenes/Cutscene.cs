using Godot;
using System;

public partial class Cutscene : Area2D
{	
	[Export]
	public Node2D checkFor;
	
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	private void _on_body_entered(Node2D body)
	{	

		GD.Print(body.Name + " | " + checkFor.Name);

		if (body == checkFor) {
			GD.Print("gotHere1");
			
		}
	}
}

