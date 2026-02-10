using Godot;
using System;

public partial class Shop : PanelContainer
{
	[Signal]
	public delegate void BuyButtonPressedEventHandler(string selectedFish);

	[Signal]
	public delegate void ExitButtonPressedEventHandler();


	[Export]
	private PackedScene fishSelectionScene;

	private GridContainer optionsGrid;

	private string currentFishSelection = null;

	private Button buyButton;

	private Button exitButton;



	public override void _Ready()
	{
		base._Ready();
		optionsGrid = GetNode<GridContainer>("%FishOptions");
		buyButton = GetNode<Button>("%BuyButton");
		exitButton = GetNode<Button>("%ExitButton");

		string[] allFishTypes = ConfigManager.Instance.GetAllFishTypes();
		foreach (string fish in allFishTypes)
		{
			FishSelection fishButton = fishSelectionScene.Instantiate<FishSelection>();
			fishButton.Text = fish;
			fishButton.Icon = FishManager.Instance.GetFishTexture(fish);
			fishButton.FishType = fish;
			fishButton.FishSelected += OnFishSelected;

			optionsGrid.AddChild(fishButton);
		}

		buyButton.Disabled = true;
	}

	public void OnFishSelected(string fishType)
	{
		currentFishSelection = fishType;
		buyButton.Disabled = false;
	}

	public void OnBuyButtonPressed()
	{
		EmitSignal(SignalName.BuyButtonPressed, currentFishSelection);
	}

	public void OnExitButtonPressed()
	{
		EmitSignal(SignalName.ExitButtonPressed);
	}
}
