using Godot;

public partial class MoneyManager : Singleton<MoneyManager>
{
	[Signal]
	public delegate void MoneyAddedEventHandler(int moneyAdded);

	[Signal]
	public delegate void MoneyRemovedEventHandler(int moneyRemoved);



	private int currentMoney;



	public override void _Ready()
	{
		base._Ready();

		SaveManager.Instance.GameLoad += OnSaveLoad;
		currentMoney = SaveManager.Instance.SaveDataCache.userMoney;
	}

	public int GetCurrentMoney()
	{
		return currentMoney;
	}

	public void AddMoney(int money)
	{
		currentMoney += money;
		EmitSignal(SignalName.MoneyAdded, money);
	}

	public bool SpendMoney(int money)
	{
		if (money <= currentMoney)
		{
			currentMoney -= money;
			EmitSignal(SignalName.MoneyRemoved, money);
			return true;
		}

		return false;
	}


	private void OnSaveLoad(SaveData data)
	{
		currentMoney = data.userMoney;
	}
}
