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

	[Export]
	private ButtonGroup fishButtonGroup;

	private GridContainer optionsGrid;

	private Button buyButton;

	private Button exitButton;

	private List<FishSelection> fishButtons;

	private Label moneyLabel;



	public override void _Ready()
	{
		base._Ready();
		fishButtons = new List<FishSelection>();

		optionsGrid = GetNode<GridContainer>("%FishOptions");
		buyButton = GetNode<Button>("%BuyButton");
		exitButton = GetNode<Button>("%ExitButton");
		moneyLabel = GetNode<Label>("%MoneyLabel");

		string[] allFishTypes = ConfigManager.Instance.GetAllFishTypes();
		int currentMoney = MoneyManager.Instance.GetCurrentMoney();
		foreach (string fish in allFishTypes)
		{
			int fishPrice = ConfigManager.Instance.GetFishCost(fish);

			FishSelection fishButton = fishSelectionScene.Instantiate<FishSelection>();
			fishButton.Text = fish + "\n$" + fishPrice.ToString();
			fishButton.Icon = FishManager.Instance.GetFishTexture(fish);
			fishButton.FishType = fish;
			fishButton.Cost = fishPrice;
			fishButton.ButtonGroup = fishButtonGroup;
			if (fishPrice > currentMoney)
			{
				fishButton.Disabled = true;
				fishButton.FocusMode = FocusModeEnum.None;
			}

			fishButtons.Add(fishButton);
		}

		fishButtons.Sort((one, two) => one.Cost - two.Cost);

		foreach (FishSelection fishButton in fishButtons)
		{
			optionsGrid.AddChild(fishButton);
		}

		fishButtonGroup.Pressed += OnFishSelected;

		buyButton.Disabled = true;
		buyButton.FocusMode = FocusModeEnum.None;

		MoneyManager.Instance.MoneyAdded += OnMoneyChanged;
		MoneyManager.Instance.MoneyRemoved += OnMoneyChanged;
	}

	public void OnFishSelected(BaseButton button)
	{
		buyButton.Disabled = false;
		buyButton.FocusMode = FocusModeEnum.All;
	}

	public void OnBuyButtonPressed()
	{
		EmitSignal(SignalName.BuyButtonPressed, (fishButtonGroup.GetPressedButton() as FishSelection).FishType);
		GD.Print($"PURCHASING {(fishButtonGroup.GetPressedButton() as FishSelection).FishType}");
	}

	public void OnExitButtonPressed()
	{
		EmitSignal(SignalName.ExitButtonPressed);
	}

	public void OnMoneyChanged(int _)
	{
		int newMoney = MoneyManager.Instance.GetCurrentMoney();

		moneyLabel.Text = $"${newMoney}";

		FishSelection selectedFish = fishButtonGroup.GetPressedButton() as FishSelection;

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

				if (fishButton == selectedFish)
				{
					fishButton.ButtonPressed = false;
					buyButton.Disabled = true;
					buyButton.FocusMode = FocusModeEnum.None;
				}
			}
		}
	}
}
