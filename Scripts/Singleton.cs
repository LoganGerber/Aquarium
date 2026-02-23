using Godot;

public abstract partial class Singleton<T> : Node where T : Singleton<T>
{
	public static T Instance { get; private set; }

	public override void _Ready()
	{
		base._Ready();
		Instance = GetNode<T>($"/root/{this.Name}");
	}
}
