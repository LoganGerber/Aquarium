using Godot;

public partial class ShopIcon : Area2D
{
	[Signal]
	public delegate void PressedEventHandler();


	[Export]
	private CompressedTexture2D defaultIcon;

	[Export]
	private CompressedTexture2D hoverIcon;


	private Sprite2D sprite;


	public override void _Ready()
	{
		base._Ready();
		sprite = GetNode<Sprite2D>("%Sprite");
		sprite.Texture = defaultIcon;

		MouseEntered += OnHover;
		MouseExited += OnUnhover;
	}

	public override void _InputEvent(Viewport _, InputEvent @event, int __)
	{
		if (@event is InputEventMouseButton mouseEvent
			&& mouseEvent.Pressed
			&& mouseEvent.ButtonIndex == MouseButton.Left)
		{
			EmitSignal(SignalName.Pressed);
		}
	}


	private void OnHover()
	{
		sprite.Texture = hoverIcon;
	}

	private void OnUnhover()
	{
		sprite.Texture = defaultIcon;
	}
}
