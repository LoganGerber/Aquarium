using Godot;
using System;
using System.Collections.Generic;

public partial class Fish : Node2D
{
	private Sprite2D sprite;

	[Export]
	private FishManager.FISH_TYPE fishType;

	private bool isHovered;

	private CapsuleShape2D collider;

	private float bobSpeed;

	private float bobPhase;

	private Texture2D texture;

	private Texture2D outlineTexture;



	[Export]
	public double Speed { get; set; }

	public int ID { get; set; }

	public double Score { get; set; }

	public FishManager.FISH_TYPE FishType
	{
		get
		{
			return fishType;
		}

		set
		{
			fishType = value;
			if (isHovered)
			{
				sprite.Texture = outlineTexture;
			}
			else
			{
				sprite.Texture = texture;
			}

			bobSpeed = ConfigManager.Instance.GetFishBobSpeed(fishType);
		}
	}

	public bool IsHovered
	{
		get
		{
			return isHovered;
		}
		set
		{
			isHovered = value;
			if (isHovered)
			{
				sprite.Texture = outlineTexture;
			}
			else
			{
				sprite.Texture = texture;
			}
		}
	}



	public override void _Ready()
	{
		sprite = GetNode<Sprite2D>("%Sprite");
		collider = (CapsuleShape2D)GetNode<CollisionShape2D>("%Collider").Shape;

		bobSpeed = ConfigManager.Instance.GetFishBobSpeed(fishType);
		ConfigManager.Instance.BobSpeedUpdated += OnBobSpeedUpdated;

		Speed = ConfigManager.Instance.GetFishSpeed(fishType);
		ConfigManager.Instance.SpeedUpdated += OnSpeedUpdated;
	}

	public override void _PhysicsProcess(double delta)
	{
		base._PhysicsProcess(delta);

		Vector2 moveVector = Vector2.Zero;


		bobPhase += (float)delta * bobSpeed;
		float bobMovement = Mathf.Sin(bobPhase * 2 * Mathf.Pi) / 5;
		moveVector.Y += bobMovement;


		Position += moveVector;
	}

	public void SetID(int ID)
	{
		this.ID = ID;
	}

	public void OnMouseEntered()
	{
		isHovered = true;
	}

	public void OnBobSpeedUpdated(string fishType, float newBobSpeed)
	{
		if (Enum.Parse<FishManager.FISH_TYPE>(fishType) == this.fishType)
		{
			bobSpeed = newBobSpeed;
		}
	}

	public void OnSpeedUpdated(string fishType, float newSpeed)
	{
		if (Enum.Parse<FishManager.FISH_TYPE>(fishType) == this.fishType)
		{
			Speed = newSpeed;
		}
	}
}
