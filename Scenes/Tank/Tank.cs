using Godot;

public partial class Tank : Control
{
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
}
