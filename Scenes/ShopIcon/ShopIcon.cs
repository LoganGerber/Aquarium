using Godot;

public partial class ShopIcon : Control
{
	[Signal]
	public delegate void PressedEventHandler();


	[Export]
	private CompressedTexture2D defaultIcon;

	[Export]
	private CompressedTexture2D hoverIcon;


	private Area2D shopIconArea;

	private Sprite2D sprite;


	public override void _Ready()
	{
		base._Ready();

		shopIconArea = GetNode<Area2D>("%ShopIconArea");
		sprite = GetNode<Sprite2D>("%Sprite");
		sprite.Texture = defaultIcon;
	}

	private void OnShopIconAreaInputEvent(Node _, InputEvent @event, int __)
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
