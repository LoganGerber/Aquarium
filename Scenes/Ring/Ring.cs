using Godot;

public partial class Ring : Area2D
{
	private Sprite2D backHalf;

	private Sprite2D frontHalf;


	public override void _Ready()
	{
		base._Ready();

		backHalf = GetNode<Sprite2D>("%BackHalf");
		frontHalf = GetNode<Sprite2D>("%FrontHalf");

		AreaEntered += OnAreaEntered;
	}


	private void OnAreaEntered(Area2D area)
	{
		Fish collidedFish = area.GetParent<Fish>();


	}
}
