using Godot;
using System;

public partial class PlayerMovement : CharacterBody2D
{
	public const float moveSpeed = 300.0f;
	public const float JumpVelocity = 400.0f;




	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	private AnimatedSprite2D _anims;

	private string dir = "idle_left";

	private bool jump = false;

	public override void _Ready()
	{
		_anims = GetNode<AnimatedSprite2D>("PlayerAnims");
	}

	public override void _PhysicsProcess(double delta) {
		Vector2 velocity = Velocity;

		if (!IsOnFloor()) {
			// Add the gravity.
			velocity.Y += gravity * (float)delta;
		} else if (IsOnFloor() && jump){
			jump = false;
		}

		// Handle Jump.
		if (Input.IsActionJustPressed("jump") && IsOnFloor()) {
			velocity.Y = -JumpVelocity;
			jump = true;
		}

		
		
		velocity.X = 0;
		if (Input.IsActionPressed("move_left")) {
			velocity.X = -moveSpeed;
		} else if (Input.IsActionPressed("move_right")) {
			velocity.X = moveSpeed;
		}

		_UpdateSpriteRenderer(velocity);
		
		Velocity = velocity;
		MoveAndSlide();
		
	}

	private void _UpdateSpriteRenderer(Vector2 vel) {
		
		if (jump) {

			if (vel.X > 0) {
				_anims.Animation = "jump_right";
				dir = "idle_right";
			} else if (vel.X < 0) {
				_anims.Animation = "jump_left";
				dir = "idle_left";
			} else {
				if (dir == "idle_right") {
					_anims.Animation = "jump_right";
				} else if (dir == "idle_left"){
					_anims.Animation = "jump_left";
				}
			}
			
		} else if (vel.X != 0) {
			if (vel.X > 0) {
				_anims.Animation = "walk_right";
				dir = "idle_right";
			} else if (vel.X < 0) {
				_anims.Animation = "walk_left";
				dir = "idle_left";
			}

		} else {
			_anims.Animation = dir;
		}
		_anims.Play();
	}
}
