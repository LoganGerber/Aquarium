using System;
using Godot;

public partial class ConfigManager : Singleton<ConfigManager>
{
	[Signal]
	public delegate void CostUpdatedEventHandler(string fishType, int newCost);

	[Signal]
	public delegate void BobSpeedUpdatedEventHandler(string fishType, float newBobSpeed);

	[Signal]
	public delegate void SpeedUpdatedEventHandler(string fishType, float newSpeed);


	private readonly string configPath = "res://Config/fishconfig.cfg";

	private ConfigFile configCache;

	private ulong configModifiedTime;


	public override void _Ready()
	{
		base._Ready();
		configCache = new ConfigFile();
		ParseConfigFile();
	}

	public override void _Process(double delta)
	{
		base._Process(delta);
		if (FileAccess.GetModifiedTime(configPath) != configModifiedTime)
		{
			ParseConfigFile();
		}
	}

	public float GetFishBobSpeed(FishManager.FISH_TYPE fishType)
	{
		return GetFishBobSpeed(Enum.GetName(fishType));
	}

	public float GetFishBobSpeed(string fishType)
	{
		return configCache.GetValue(fishType, "bobSpeed").AsSingle();
	}

	public int GetFishCost(FishManager.FISH_TYPE fishType)
	{
		return GetFishCost(Enum.GetName(fishType));
	}

	public int GetFishCost(string fishType)
	{
		return configCache.GetValue(fishType, "cost").AsInt32();
	}

	public float GetFishSpeed(FishManager.FISH_TYPE fishType)
	{
		return GetFishSpeed(Enum.GetName(fishType));
	}

	public float GetFishSpeed(string fishType)
	{
		return configCache.GetValue(fishType, "speed").AsSingle();
	}


	private void ParseConfigFile()
	{
		ConfigFile config = new ConfigFile();
		config.Load(configPath);

		foreach (string fishType in Enum.GetNames<FishManager.FISH_TYPE>())
		{
			if (config.HasSection(fishType))
			{
				float speed = config.GetValue(fishType, "speed", 9999).AsSingle();
				float bobSpeed = config.GetValue(fishType, "bobSpeed", 30).AsSingle();
				int cost = config.GetValue(fishType, "cost", 9999).AsInt32();


				if (configCache.GetValue(fishType, "bobSpeed", float.PositiveInfinity).AsSingle() != bobSpeed)
				{
					EmitSignal(SignalName.BobSpeedUpdated, fishType, bobSpeed);
				}

				if (configCache.GetValue(fishType, "cost", -1).AsInt32() != cost)
				{
					EmitSignal(SignalName.CostUpdated, fishType, cost);
				}

				if (configCache.GetValue(fishType, "speed", float.PositiveInfinity).AsSingle() != speed)
				{
					EmitSignal(SignalName.SpeedUpdated, fishType, speed);
				}
			}
		}

		configCache = config;
		configModifiedTime = FileAccess.GetModifiedTime(configPath);
	}
}
