using System.Collections.Generic;
using Godot;

public partial class ClickthroughManager : Singleton<ClickthroughManager>
{
	private readonly List<IClickable> clickableItems = new List<IClickable>();


	public override void _Ready()
	{
		base._Ready();
		GetParent().CallDeferred("move_child", this, -1);
		// GetTree().NodeAdded += OnNodeAdded;
	}

	public override void _Process(double delta)
	{
		base._Process(delta);

		if (clickableItems.Count == 0)
		{
			DisplayServer.WindowSetMousePassthrough([]);
			return;
		}

		IClickable closest = clickableItems[0];
		float closestDistance = closest.GetDistanceToCursor();

		for (int i = 1; i < clickableItems.Count; i++)
		{
			IClickable clickable = clickableItems[i];
			float distance = clickable.GetDistanceToCursor();

			if (distance < closestDistance)
			{
				closest = clickable;
				closestDistance = distance;
			}
		}

		GetViewport().GetWindow().MousePassthroughPolygon = closest.GetClickablePolygon();

		// DisplayServer.WindowSetMousePassthrough(closest.GetClickablePolygon());
	}


	public void RegisterClickable(IClickable clickable)
	{
		clickableItems.Add(clickable);
	}

	private void OnNodeAdded(Node newNode)
	{
		if (newNode == this)
		{
			return;
		}
		GD.Print("AAAAAAAAAAAAAAAAAAAAAAAAAAAAA");

		GetParent().CallDeferred("move_child", this, -1);
	}
}
