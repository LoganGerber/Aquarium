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


	private Array<FishData> allFish;

	private int maxID;


	public override void _Ready()
	{
		base._Ready();
		SaveManager.Instance.GameLoad += OnSaveLoad;
		SetFishList(SaveManager.Instance.SaveDataCache.fishInfo);
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

	public void OnFishPurchased(Fish.FISH_TYPE fishType)
	{
		FishData newFish = new FishData(++maxID, Enum.GetName(fishType), 0);
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
}
