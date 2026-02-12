using Godot;
using System.Collections.Generic;

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

	private List<FishSelection> fishButtons;



	public override void _Ready()
	{
		base._Ready();
		fishButtons = new List<FishSelection>();

		optionsGrid = GetNode<GridContainer>("%FishOptions");
		buyButton = GetNode<Button>("%BuyButton");
		exitButton = GetNode<Button>("%ExitButton");

		string[] allFishTypes = ConfigManager.Instance.GetAllFishTypes();
		int currentMoney = MoneyManager.Instance.GetCurrentMoney();
		foreach (string fish in allFishTypes)
		{
			int fishPrice = ConfigManager.Instance.GetFishCost(fish);

			FishSelection fishButton = fishSelectionScene.Instantiate<FishSelection>();
			fishButton.Text = fish + "\n$" + fishPrice.ToString();
			fishButton.Icon = FishManager.Instance.GetFishTexture(fish);
			fishButton.FishType = fish;
			fishButton.FishSelected += OnFishSelected;
			if (fishPrice > currentMoney)
			{
				fishButton.Disabled = true;
				fishButton.FocusMode = FocusModeEnum.None;

			}

			optionsGrid.AddChild(fishButton);
			fishButtons.Add(fishButton);
		}

		buyButton.Disabled = true;

		MoneyManager.Instance.MoneyAdded += OnMoneyChanged;
		MoneyManager.Instance.MoneyRemoved += OnMoneyChanged;
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

	public void OnMoneyChanged(int _)
	{
		int newMoney = MoneyManager.Instance.GetCurrentMoney();

		foreach (FishSelection fishButton in fishButtons)
		{
			string fishType = fishButton.FishType;
			int fishPrice = ConfigManager.Instance.GetFishCost(fishType);

			if (fishPrice <= newMoney)
			{
				fishButton.Disabled = false;
				fishButton.FocusMode = FocusModeEnum.All;
			}
			else
			{
				fishButton.Disabled = true;
				fishButton.FocusMode = FocusModeEnum.None;
			}
		}
	}
}
