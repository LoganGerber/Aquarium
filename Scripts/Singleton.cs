using Godot;
using System;

public abstract partial class Singleton<T> : Node where T : Singleton<T>
{
	private static Lazy<T> instance;

	public static T Instance
	{
		get
		{
			return instance.Value;
		}
	}

	public override void _Ready()
	{
		base._Ready();
		instance = new Lazy<T>(() => GetNode<T>($"/root/{this.Name}"));
	}
}
