using Godot;
using Godot.Collections;
using System;
using System.Linq;

public partial class FishManager : Singleton<FishManager>
{
	[Signal]
	public delegate void FishListUpdatedEventHandler(Array<FishData> fishList);

	[Signal]
	public delegate void FishAddedEventHandler(FishData newFish);

	[Signal]
	public delegate void FishRemovedEventHandler(int ID);


	private Dictionary<string, Texture2D> fishTexture;

	private Dictionary<string, Texture2D> fishOutlineTexture;



	private Array<FishData> allFish;

	private int maxID;


	public override void _Ready()
	{
		base._Ready();
		SaveManager.Instance.GameLoad += OnSaveLoad;
		SetFishList(SaveManager.Instance.SaveDataCache.fishInfo);

		string[] fishTypes = ConfigManager.Instance.GetAllFishTypes();

		fishTexture = new Dictionary<string, Texture2D>();
		fishOutlineTexture = new Dictionary<string, Texture2D>();
		foreach (string fishType in fishTypes)
		{
			fishTexture[fishType] = GD.Load<Texture2D>(ConfigManager.Instance.GetTexturePath(fishType));
			fishOutlineTexture[fishType] = GD.Load<Texture2D>(ConfigManager.Instance.GetOutlineTexturePath(fishType));
		}
	}

	public FishData GetFishDataByID(int ID)
	{
		return allFish.First((fish) => fish.ID == ID);
	}

	public Array<FishData> GetAllFishData()
	{
		return new Array<FishData>(allFish);
	}

	public void OnSaveLoad(SaveData data)
	{
		SetFishList(data.fishInfo);
	}

	public void OnFishPurchased(string fishType)
	{
		FishData newFish = new FishData(++maxID, fishType, 0);
		allFish.Add(newFish);

		EmitSignal(SignalName.FishAdded, newFish);
	}

	public void OnFishSold(int ID)
	{
		allFish.Remove(allFish.First((fish) => fish.ID == ID));

		EmitSignal(SignalName.FishRemoved, ID);
	}

	private void SetFishList(Array<FishData> fishData)
	{
		allFish = new Array<FishData>(fishData);

		if (allFish.Count == 0)
		{
			maxID = 0;
		}
		else
		{
			maxID = fishData.Max((fish) => fish.ID);
		}

		EmitSignal(SignalName.FishListUpdated, allFish);
	}

	public Texture2D GetFishTexture(string fishType)
	{
		return fishTexture[fishType];
	}

	public Texture2D GetFishOutlineTexture(string fishType)
	{
		return fishOutlineTexture[fishType];
	}
}
