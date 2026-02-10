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

	[Signal]
	public delegate void TextureUpdatedEventHandler(string fishType, string newTexturePath);

	[Signal]
	public delegate void OutlineTextureUpdatedEventHandler(string fishType, string newOutlineTexturePath);



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

	public float GetFishBobSpeed(string fishType)
	{
		return configCache.GetValue(fishType, "bobSpeed").AsSingle();
	}

	public int GetFishCost(string fishType)
	{
		return configCache.GetValue(fishType, "cost").AsInt32();
	}

	public float GetFishSpeed(string fishType)
	{
		return configCache.GetValue(fishType, "speed").AsSingle();
	}

	public string GetTexturePath(string fishType)
	{
		return configCache.GetValue(fishType, "texture").AsString();
	}

	public string GetOutlineTexturePath(string fishType)
	{
		return configCache.GetValue(fishType, "outlineTexture").AsString();
	}

	public string[] GetAllFishTypes()
	{
		return configCache.GetSections();
	}


	private void ParseConfigFile()
	{
		ConfigFile config = new ConfigFile();
		config.Load(configPath);

		string[] fishTypes = config.GetSections();

		foreach (string fishType in fishTypes)
		{
			float speed = config.GetValue(fishType, "speed", 9999).AsSingle();
			float bobSpeed = config.GetValue(fishType, "bobSpeed", 30).AsSingle();
			int cost = config.GetValue(fishType, "cost", 9999).AsInt32();
			string texturePath = config.GetValue(fishType, "texture").AsString();
			string outlineTexturePath = config.GetValue(fishType, "outlineTexture").AsString();


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

			if (configCache.GetValue(fishType, "texture", "").AsString() != texturePath)
			{
				EmitSignal(SignalName.TextureUpdated, fishType, texturePath);
			}

			if (configCache.GetValue(fishType, "outlineTexture", "").AsString() != outlineTexturePath)
			{
				EmitSignal(SignalName.OutlineTextureUpdated, fishType, outlineTexturePath);
			}
		}

		configCache = config;
		configModifiedTime = FileAccess.GetModifiedTime(configPath);
	}
}
