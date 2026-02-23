using Godot;

public interface IClickable
{
	public Vector2[] GetClickablePolygon();

	public float GetDistanceToCursor();
}
