using Godot;

public partial class FishSelection : Button
{
	[Signal]
	public delegate void FishSelectedEventHandler(string fishType);


	public string FishType { get; set; }

	public int Cost { get; set; }


	public override void _Ready()
	{
		base._Ready();
		Pressed += OnPressed;
	}


	public void OnPressed()
	{
		EmitSignal(SignalName.FishSelected, FishType);
	}
}
