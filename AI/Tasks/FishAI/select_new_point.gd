@tool
extends BTAction

var visibleRect: Rect2

func _setup() -> void:
	visibleRect = agent.get_viewport().get_visible_rect()

func _tick(_delta: float) -> Status:
	blackboard.set_var(&"RandomLocation", Vector2(
			randf() * visibleRect.size.x,
			randf() * visibleRect.size.y
		)
	)

	return SUCCESS
