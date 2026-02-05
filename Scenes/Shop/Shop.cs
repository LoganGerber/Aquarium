using Godot;
using System;

public partial class Shop : PanelContainer
{
	[Export]
	private PackedScene fishSelectionScene;

	private GridContainer optionsGrid;

	public override void _Ready()
	{
		base._Ready();
		optionsGrid = GetNode<GridContainer>("%FishOptions");

		FishManager.FISH_TYPE[] allFishTypes = Enum.GetValues<FishManager.FISH_TYPE>();
		foreach (FishManager.FISH_TYPE fish in allFishTypes)
		{
			Button fishButton = fishSelectionScene.Instantiate<Button>();
			fishButton.Text = FishManager.GetHumanReadableFishName(fish);
			fishButton.Icon = FishManager.GetFishTexture(fish);

			optionsGrid.AddChild(fishButton);
		}
	}
}
