using Godot;
using Godot.Collections;

public partial class SaveManager : Singleton<SaveManager>
{
	[Signal]
	public delegate void GameLoadEventHandler(SaveData data);

	[Signal]
	public delegate void GameSaveEventHandler();


	private readonly string savePath = "user://usersav.tres";

	private SaveData saveDataCache;


	public SaveData SaveDataCache
	{
		get
		{
			return (SaveData)saveDataCache.DuplicateDeep(Resource.DeepDuplicateMode.All);
		}
	}


	public override void _Ready()
	{
		base._Ready();
		Load();
	}

	private void Save()
	{
		saveDataCache.fishInfo = FishManager.Instance.GetAllFishData();
		saveDataCache.userMoney = MoneyManager.Instance.GetCurrentMoney();

		Error err = ResourceSaver.Save(saveDataCache, savePath);
		if (err != Error.Ok)
		{
			// TODO: Failed to save data, error handle
		}

		EmitSignal(SignalName.GameSave);
	}

	private void Load()
	{
		if (ResourceLoader.Exists(savePath))
		{
			saveDataCache = ResourceLoader.Load<SaveData>(savePath, cacheMode: ResourceLoader.CacheMode.Ignore);
			EmitSignal(SignalName.GameLoad, (SaveData)saveDataCache.DuplicateDeep(Resource.DeepDuplicateMode.All));
		}
		else
		{
			saveDataCache = new SaveData();
			saveDataCache.userMoney = 0;
			saveDataCache.fishInfo = new Array<FishData>();
		}
	}
}
