using Godot;

public partial class Fish : Node2D
{
	private Sprite2D sprite;

	[Export]
	private string fishType;

	[Export]
	private Texture2D texture;

	[Export]
	private Texture2D outlineTexture;

	[Export]
	private double speed;

	private bool isHovered;

	private float bobSpeed;

	private float bobPhase;



	public int ID { get; set; }

	public double Score { get; set; }

	public string FishType
	{
		get
		{
			return fishType;
		}

		set
		{
			fishType = value;

			texture = FishManager.Instance.GetFishTexture(fishType);
			outlineTexture = FishManager.Instance.GetFishOutlineTexture(fishType);
			bobSpeed = ConfigManager.Instance.GetFishBobSpeed(fishType);
			speed = ConfigManager.Instance.GetFishSpeed(fishType);

			if (IsNodeReady())
			{
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
		sprite.Texture = texture;

		bobSpeed = ConfigManager.Instance.GetFishBobSpeed(fishType);
		ConfigManager.Instance.BobSpeedUpdated += OnBobSpeedUpdated;

		speed = ConfigManager.Instance.GetFishSpeed(fishType);
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
		IsHovered = true;
	}

	public void OnMouseExited()
	{
		IsHovered = false;
	}

	public void OnFishAreaInputEvent(Node _, InputEvent ev, int __)
	{
		if (ev is InputEventMouseButton mouseEvent
			&& mouseEvent.Pressed
			&& mouseEvent.ButtonIndex == MouseButton.Left)
		{
			GD.Print("Fish mouse button event");
		}
	}

	public void OnBobSpeedUpdated(string fishType, float newBobSpeed)
	{
		if (string.Equals(fishType, this.fishType))
		{
			bobSpeed = newBobSpeed;
		}
	}

	public void OnSpeedUpdated(string fishType, float newSpeed)
	{
		if (string.Equals(fishType, this.fishType))
		{
			speed = newSpeed;
		}
	}
}
