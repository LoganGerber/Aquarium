using Godot;
using Godot.Collections;

public partial class SaveData : Resource
{
	[Export]
	public Array<FishData> fishInfo;

	[Export]
	public int userMoney;
}
