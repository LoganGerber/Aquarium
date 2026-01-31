using Godot;
using System;
using System.Collections.Generic;

public partial class Fish : Node2D
{
	private static readonly Texture2D AngelfishTexture = GD.Load<Texture2D>("res://assets/Pixel Gnome Fishing Pack/Fresh Water/Angelfish.png");
	private static readonly Texture2D AngelfishOutlineTexture = GD.Load<Texture2D>("res://assets/Pixel Gnome Fishing Pack/Fresh Water/Angelfish Outline.png");
	private static readonly Texture2D ArowanaTexture = GD.Load<Texture2D>("res://assets/Pixel Gnome Fishing Pack/Fresh Water/Arowana.png");
	private static readonly Texture2D ArowanaOutlineTexture = GD.Load<Texture2D>("res://assets/Pixel Gnome Fishing Pack/Fresh Water/Arowana Outline.png");
	private static readonly Texture2D BassTexture = GD.Load<Texture2D>("res://assets/Pixel Gnome Fishing Pack/Fresh Water/Bass.png");
	private static readonly Texture2D BassOutlineTexture = GD.Load<Texture2D>("res://assets/Pixel Gnome Fishing Pack/Fresh Water/Bass Outline.png");
	private static readonly Texture2D BluegillTexture = GD.Load<Texture2D>("res://assets/Pixel Gnome Fishing Pack/Fresh Water/Bluegill.png");
	private static readonly Texture2D BluegillOutlineTexture = GD.Load<Texture2D>("res://assets/Pixel Gnome Fishing Pack/Fresh Water/Bluegill Outline.png");
	private static readonly Texture2D CarpTexture = GD.Load<Texture2D>("res://assets/Pixel Gnome Fishing Pack/Fresh Water/Carp.png");
	private static readonly Texture2D CarpOutlineTexture = GD.Load<Texture2D>("res://assets/Pixel Gnome Fishing Pack/Fresh Water/Carp Outline.png");
	private static readonly Texture2D CatfishTexture = GD.Load<Texture2D>("res://assets/Pixel Gnome Fishing Pack/Fresh Water/Catfish.png");
	private static readonly Texture2D CatfishOutlineTexture = GD.Load<Texture2D>("res://assets/Pixel Gnome Fishing Pack/Fresh Water/Catfish Outline.png");
	private static readonly Texture2D GoldfishTexture = GD.Load<Texture2D>("res://assets/Pixel Gnome Fishing Pack/Fresh Water/Goldfish.png");
	private static readonly Texture2D GoldfishOutlineTexture = GD.Load<Texture2D>("res://assets/Pixel Gnome Fishing Pack/Fresh Water/Goldfish Outline.png");
	private static readonly Texture2D GuppyTexture = GD.Load<Texture2D>("res://assets/Pixel Gnome Fishing Pack/Fresh Water/Guppy.png");
	private static readonly Texture2D GuppyOutlineTexture = GD.Load<Texture2D>("res://assets/Pixel Gnome Fishing Pack/Fresh Water/Guppy Outline.png");
	private static readonly Texture2D NeonTetraTexture = GD.Load<Texture2D>("res://assets/Pixel Gnome Fishing Pack/Fresh Water/NeonTetra.png");
	private static readonly Texture2D NeonTetraOutlineTexture = GD.Load<Texture2D>("res://assets/Pixel Gnome Fishing Pack/Fresh Water/Neon Tetra Outline.png");
	private static readonly Texture2D RainbowTroutTexture = GD.Load<Texture2D>("res://assets/Pixel Gnome Fishing Pack/Fresh Water/Rainbow Trout.png");
	private static readonly Texture2D RainbowTroutOutlineTexture = GD.Load<Texture2D>("res://assets/Pixel Gnome Fishing Pack/Fresh Water/Rainbow Trout Outline.png");
	private static readonly Texture2D SalmonTexture = GD.Load<Texture2D>("res://assets/Pixel Gnome Fishing Pack/Fresh Water/Salmon.png");
	private static readonly Texture2D SalmonOutlineTexture = GD.Load<Texture2D>("res://assets/Pixel Gnome Fishing Pack/Fresh Water/Salmon Outline.png");
	private static readonly Texture2D SilverjawMinnowTexture = GD.Load<Texture2D>("res://assets/Pixel Gnome Fishing Pack/Fresh Water/Silverjaw Minnow.png");
	private static readonly Texture2D SilverjawMinnowOutlineTexture = GD.Load<Texture2D>("res://assets/Pixel Gnome Fishing Pack/Fresh Water/Silverjaw Minnow Outline.png");
	private static readonly Texture2D YellowPerchTexture = GD.Load<Texture2D>("res://assets/Pixel Gnome Fishing Pack/Fresh Water/Yellow Perch.png");
	private static readonly Texture2D YellowPerchOutlineTexture = GD.Load<Texture2D>("res://assets/Pixel Gnome Fishing Pack/Fresh Water/Yellow Perch Outline.png");
	private static readonly Texture2D AnchovyTexture = GD.Load<Texture2D>("res://assets/Pixel Gnome Fishing Pack/Salt Water/Anchovy.png");
	private static readonly Texture2D AnchovyOutlineTexture = GD.Load<Texture2D>("res://assets/Pixel Gnome Fishing Pack/Salt Water/Anchovy Outline.png");
	private static readonly Texture2D AnglerfishTexture = GD.Load<Texture2D>("res://assets/Pixel Gnome Fishing Pack/Salt Water/Anglerfish.png");
	private static readonly Texture2D AnglerfishOutlineTexture = GD.Load<Texture2D>("res://assets/Pixel Gnome Fishing Pack/Salt Water/Anglerfish Outline.png");
	private static readonly Texture2D BlueAngelfishTexture = GD.Load<Texture2D>("res://assets/Pixel Gnome Fishing Pack/Salt Water/Blue Angelfish.png");
	private static readonly Texture2D BlueAngelfishOutlineTexture = GD.Load<Texture2D>("res://assets/Pixel Gnome Fishing Pack/Salt Water/Blue Angelfish Outline.png");
	private static readonly Texture2D BlueGroperTexture = GD.Load<Texture2D>("res://assets/Pixel Gnome Fishing Pack/Salt Water/Blue Groper.png");
	private static readonly Texture2D BlueGroperOutlineTexture = GD.Load<Texture2D>("res://assets/Pixel Gnome Fishing Pack/Salt Water/Blue Groper Outline.png");
	private static readonly Texture2D ClownfishTexture = GD.Load<Texture2D>("res://assets/Pixel Gnome Fishing Pack/Salt Water/Clownfish.png");
	private static readonly Texture2D ClownfishOutlineTexture = GD.Load<Texture2D>("res://assets/Pixel Gnome Fishing Pack/Salt Water/Clownfish Outline.png");
	private static readonly Texture2D FlounderTexture = GD.Load<Texture2D>("res://assets/Pixel Gnome Fishing Pack/Salt Water/Flounder.png");
	private static readonly Texture2D FlounderOutlineTexture = GD.Load<Texture2D>("res://assets/Pixel Gnome Fishing Pack/Salt Water/Flounder Outline.png");
	private static readonly Texture2D GobyTexture = GD.Load<Texture2D>("res://assets/Pixel Gnome Fishing Pack/Salt Water/Goby.png");
	private static readonly Texture2D GobyOutlineTexture = GD.Load<Texture2D>("res://assets/Pixel Gnome Fishing Pack/Salt Water/Goby Outline.png");
	private static readonly Texture2D GreatWhiteSharkTexture = GD.Load<Texture2D>("res://assets/Pixel Gnome Fishing Pack/Salt Water/Great White Shark.png");
	private static readonly Texture2D GreatWhiteSharkOutlineTexture = GD.Load<Texture2D>("res://assets/Pixel Gnome Fishing Pack/Salt Water/Great White Shark Outline.png");
	private static readonly Texture2D JellyfishTexture = GD.Load<Texture2D>("res://assets/Pixel Gnome Fishing Pack/Salt Water/Jellyfish.png");
	private static readonly Texture2D JellyfishOutlineTexture = GD.Load<Texture2D>("res://assets/Pixel Gnome Fishing Pack/Salt Water/Jellyfish Outline.png");
	private static readonly Texture2D NapoleonWrasseTexture = GD.Load<Texture2D>("res://assets/Pixel Gnome Fishing Pack/Salt Water/Napoleon Wrasse.png");
	private static readonly Texture2D NapoleonWrasseOutlineTexture = GD.Load<Texture2D>("res://assets/Pixel Gnome Fishing Pack/Salt Water/Napoleon Wrasse Outline.png");
	private static readonly Texture2D PufferfishTexture = GD.Load<Texture2D>("res://assets/Pixel Gnome Fishing Pack/Salt Water/Pufferfish.png");
	private static readonly Texture2D PufferfishOutlineTexture = GD.Load<Texture2D>("res://assets/Pixel Gnome Fishing Pack/Salt Water/Pufferfish Outline.png");
	private static readonly Texture2D PurpleTangTexture = GD.Load<Texture2D>("res://assets/Pixel Gnome Fishing Pack/Salt Water/Purple Tang.png");
	private static readonly Texture2D PurpleTangOutlineTexture = GD.Load<Texture2D>("res://assets/Pixel Gnome Fishing Pack/Salt Water/Purple Tang Outline.png");
	private static readonly Texture2D SeahorseTexture = GD.Load<Texture2D>("res://assets/Pixel Gnome Fishing Pack/Salt Water/Seahorse.png");
	private static readonly Texture2D SeahorseOutlineTexture = GD.Load<Texture2D>("res://assets/Pixel Gnome Fishing Pack/Salt Water/Seahorse Outline.png");
	private static readonly Texture2D SurgeonfishTexture = GD.Load<Texture2D>("res://assets/Pixel Gnome Fishing Pack/Salt Water/Surgeonfish.png");
	private static readonly Texture2D SurgeonfishOutlineTexture = GD.Load<Texture2D>("res://assets/Pixel Gnome Fishing Pack/Salt Water/Surgeonfish Outline.png");
	private static readonly Texture2D TunaTexture = GD.Load<Texture2D>("res://assets/Pixel Gnome Fishing Pack/Salt Water/Tuna.png");
	private static readonly Texture2D TunaOutlineTexture = GD.Load<Texture2D>("res://assets/Pixel Gnome Fishing Pack/Salt Water/Tuna Outline.png");
	private static readonly Texture2D YellowTangTexture = GD.Load<Texture2D>("res://assets/Pixel Gnome Fishing Pack/Salt Water/Yellow Tang.png");
	private static readonly Texture2D YellowTangOutlineTexture = GD.Load<Texture2D>("res://assets/Pixel Gnome Fishing Pack/Salt Water/Yellow Tang Outline.png");



	public enum FISH_TYPE
	{
		Angelfish,
		Arowana,
		Bass,
		Bluegill,
		Carp,
		Catfish,
		Goldfish,
		Guppy,
		NeonTetra,
		RainbowTrout,
		Salmon,
		SilverjawMinnow,
		YellowPerch,
		Anchovy,
		Anglerfish,
		BlueAngelfish,
		BlueGroper,
		Clownfish,
		Flounder,
		Goby,
		GreatWhiteShark,
		Jellyfish,
		NapoleonWrasse,
		Pufferfish,
		PurpleTang,
		Seahorse,
		Surgeonfish,
		Tuna,
		YellowTang
	}



	private static readonly Dictionary<FISH_TYPE, Texture2D> fishTexture = new()
	{
		{FISH_TYPE.Angelfish, AngelfishTexture},
		{FISH_TYPE.Arowana, ArowanaTexture},
		{FISH_TYPE.Bass, BassTexture},
		{FISH_TYPE.Bluegill, BluegillTexture},
		{FISH_TYPE.Carp, CarpTexture},
		{FISH_TYPE.Catfish, CatfishTexture},
		{FISH_TYPE.Goldfish, GoldfishTexture},
		{FISH_TYPE.Guppy, GuppyTexture},
		{FISH_TYPE.NeonTetra, NeonTetraTexture},
		{FISH_TYPE.RainbowTrout, RainbowTroutTexture},
		{FISH_TYPE.Salmon, SalmonTexture},
		{FISH_TYPE.SilverjawMinnow, SilverjawMinnowTexture},
		{FISH_TYPE.YellowPerch, YellowPerchTexture},
		{FISH_TYPE.Anchovy, AnchovyTexture},
		{FISH_TYPE.Anglerfish, AnglerfishTexture},
		{FISH_TYPE.BlueAngelfish, BlueAngelfishTexture},
		{FISH_TYPE.BlueGroper, BlueGroperTexture},
		{FISH_TYPE.Clownfish, ClownfishTexture},
		{FISH_TYPE.Flounder, FlounderTexture},
		{FISH_TYPE.Goby, GobyTexture},
		{FISH_TYPE.GreatWhiteShark, GreatWhiteSharkTexture},
		{FISH_TYPE.Jellyfish, JellyfishTexture},
		{FISH_TYPE.NapoleonWrasse, NapoleonWrasseTexture},
		{FISH_TYPE.Pufferfish, PufferfishTexture},
		{FISH_TYPE.PurpleTang, PurpleTangTexture},
		{FISH_TYPE.Seahorse, SeahorseTexture},
		{FISH_TYPE.Surgeonfish, SurgeonfishTexture},
		{FISH_TYPE.Tuna, TunaTexture},
		{FISH_TYPE.YellowTang, YellowTangTexture}
	};

	private static readonly Dictionary<FISH_TYPE, Texture2D> fishOutlineTexture = new()
	{
		{FISH_TYPE.Angelfish, AngelfishOutlineTexture},
		{FISH_TYPE.Arowana, ArowanaOutlineTexture},
		{FISH_TYPE.Bass, BassOutlineTexture},
		{FISH_TYPE.Bluegill, BluegillOutlineTexture},
		{FISH_TYPE.Carp, CarpOutlineTexture},
		{FISH_TYPE.Catfish, CatfishOutlineTexture},
		{FISH_TYPE.Goldfish, GoldfishOutlineTexture},
		{FISH_TYPE.Guppy, GuppyOutlineTexture},
		{FISH_TYPE.NeonTetra, NeonTetraOutlineTexture},
		{FISH_TYPE.RainbowTrout, RainbowTroutOutlineTexture},
		{FISH_TYPE.Salmon, SalmonOutlineTexture},
		{FISH_TYPE.SilverjawMinnow, SilverjawMinnowOutlineTexture},
		{FISH_TYPE.YellowPerch, YellowPerchOutlineTexture},
		{FISH_TYPE.Anchovy, AnchovyOutlineTexture},
		{FISH_TYPE.Anglerfish, AnglerfishOutlineTexture},
		{FISH_TYPE.BlueAngelfish, BlueAngelfishOutlineTexture},
		{FISH_TYPE.BlueGroper, BlueGroperOutlineTexture},
		{FISH_TYPE.Clownfish, ClownfishOutlineTexture},
		{FISH_TYPE.Flounder, FlounderOutlineTexture},
		{FISH_TYPE.Goby, GobyOutlineTexture},
		{FISH_TYPE.GreatWhiteShark, GreatWhiteSharkOutlineTexture},
		{FISH_TYPE.Jellyfish, JellyfishOutlineTexture},
		{FISH_TYPE.NapoleonWrasse, NapoleonWrasseOutlineTexture},
		{FISH_TYPE.Pufferfish, PufferfishOutlineTexture},
		{FISH_TYPE.PurpleTang, PurpleTangOutlineTexture},
		{FISH_TYPE.Seahorse, SeahorseOutlineTexture},
		{FISH_TYPE.Surgeonfish, SurgeonfishOutlineTexture},
		{FISH_TYPE.Tuna, TunaOutlineTexture},
		{FISH_TYPE.YellowTang, YellowTangOutlineTexture}
	};



	private Sprite2D sprite;

	[Export]
	private FISH_TYPE fishType;

	private bool isHovered;

	private CapsuleShape2D collider;

	private float bobSpeed;

	private float bobPhase;



	[Export]
	public double Speed { get; set; }

	public int ID { get; set; }

	public double Score { get; set; }

	public FISH_TYPE FishType
	{
		get
		{
			return fishType;
		}

		set
		{
			fishType = value;
			if (isHovered)
			{
				sprite.Texture = fishOutlineTexture[fishType];
			}
			else
			{
				sprite.Texture = fishTexture[fishType];
			}

			bobSpeed = ConfigManager.Instance.GetFishBobSpeed(fishType);
		}
	}

	public bool IsHovered
	{
		get
		{
			return isHovered;
		}
		set
		{
			isHovered = value;
			if (isHovered)
			{
				sprite.Texture = fishOutlineTexture[fishType];
			}
			else
			{
				sprite.Texture = fishTexture[fishType];
			}
		}
	}



	public override void _Ready()
	{
		sprite = GetNode<Sprite2D>("%Sprite");
		collider = (CapsuleShape2D)GetNode<CollisionShape2D>("%Collider").Shape;

		bobSpeed = ConfigManager.Instance.GetFishBobSpeed(fishType);
		ConfigManager.Instance.BobSpeedUpdated += OnBobSpeedUpdated;

		Speed = ConfigManager.Instance.GetFishSpeed(fishType);
		ConfigManager.Instance.SpeedUpdated += OnSpeedUpdated;
	}

	public override void _PhysicsProcess(double delta)
	{
		base._PhysicsProcess(delta);

		Vector2 moveVector = Vector2.Zero;


		bobPhase += (float)delta * bobSpeed;
		float bobMovement = Mathf.Sin(bobPhase * 2 * Mathf.Pi) / 5;
		moveVector.Y += bobMovement;


		Position += moveVector;
	}

	public void SetID(int ID)
	{
		this.ID = ID;
	}

	public void OnMouseEntered()
	{
		isHovered = true;
	}

	public void OnBobSpeedUpdated(string fishType, float newBobSpeed)
	{
		if (Enum.Parse<FISH_TYPE>(fishType) == this.fishType)
		{
			bobSpeed = newBobSpeed;
		}
	}

	public void OnSpeedUpdated(string fishType, float newSpeed)
	{
		if (Enum.Parse<FISH_TYPE>(fishType) == this.fishType)
		{
			Speed = newSpeed;
		}
	}
}
