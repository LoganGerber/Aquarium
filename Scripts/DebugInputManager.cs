using Godot;

public partial class DebugInputManager : Singleton<DebugInputManager>
{
	public override void _UnhandledKeyInput(InputEvent @event)
	{
		if (@event is InputEventKey keyEvent)
		{
			if (keyEvent.Pressed)
			{
				if (keyEvent.Keycode == Key.Minus)
				{
					MoneyManager.Instance.SpendMoney(20);
					GD.Print($"DEBUG: Removing money. New total = {MoneyManager.Instance.GetCurrentMoney()}");
					GetViewport().SetInputAsHandled();
				}
				else if (keyEvent.Keycode == Key.Equal)
				{
					MoneyManager.Instance.AddMoney(20);
					GD.Print($"DEBUG: Adding money. New total = {MoneyManager.Instance.GetCurrentMoney()}");
					GetViewport().SetInputAsHandled();
				}
			}
		}
	}
}
