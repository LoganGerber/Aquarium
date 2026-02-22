using Godot;
using System;

public partial class Tank : Control
{
	[Export]
	private PackedScene fishScene;


	private FishManager fishManager;
	private Shop shop;
	private TextureButton shopIcon;



	public override void _Ready()
	{
		base._Ready();

		shop = GetNode<Shop>("%Shop");
		shopIcon = GetNode<TextureButton>("%ShopIcon");

		DisableShop();
		shop.ExitButtonPressed += OnShopExitButtonPressed;

		FishManager.Instance.FishAdded += OnFishAdded;
	}

	public void OnShopIconPressed()
	{
		EnableShop();
	}

	public void OnShopExitButtonPressed()
	{
		DisableShop();
	}


	private void EnableShop()
	{
		shop.Visible = true;
		shopIcon.Visible = false;
	}

	private void DisableShop()
	{
		shop.Visible = false;
		shopIcon.Visible = true;
	}

	private void OnFishAdded(FishData fishData)
	{
		Fish newFish = fishScene.Instantiate<Fish>();

		Random rand = new Random();
		Vector2 screenSize = GetViewport().GetVisibleRect().Size;
		newFish.GlobalPosition = new Vector2(
			rand.NextSingle() * screenSize.X,
			rand.NextSingle() * screenSize.Y
		);

		newFish.FishType = fishData.FishType;
		newFish.Name = $"Fish{newFish.ID}";
		newFish.ID = fishData.ID;
		newFish.Score = fishData.Score;

		AddChild(newFish);
		MoveChild(newFish, 0);
	}
}
