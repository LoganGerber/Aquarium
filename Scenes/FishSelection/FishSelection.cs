using Godot;
using System;

public partial class FishSelection : PanelContainer
{
	private readonly StyleBoxFlat unselected = GD.Load<StyleBoxFlat>("res://Scenes/FishSelection/Styles/Unselected.tres");
	private readonly StyleBoxFlat selected = GD.Load<StyleBoxFlat>("res://Scenes/FishSelection/Styles/Selected.tres");
	private readonly StyleBoxFlat hovered = GD.Load<StyleBoxFlat>("res://Scenes/FishSelection/Styles/Hovered.tres");


	public override void _Ready()
	{
		base._Ready();
		Button button = GetNode<Button>("%Button");
		button.Toggled += OnToggled;
		button.MouseEntered += OnMouseEntered;
		button.MouseExited += OnMouseExited;
	}

	private void OnToggled(bool toggledOn)
	{

	}

	private void OnMouseEntered()
	{

	}

	private void OnMouseExited()
	{

	}
}
