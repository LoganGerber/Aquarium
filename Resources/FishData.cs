using Godot;

public partial class FishData : Resource
{
	[Export]
	public int ID;

	[Export]
	public string FishType;

	[Export]
	public double Score;


	public FishData()
	{

	}

	public FishData(int id, string fishType, double score)
	{
		ID = id;
		FishType = fishType;
		Score = score;
	}
}
