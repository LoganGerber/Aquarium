@tool
extends BTAction

var agent2D: Node2D
var agentSprite: Sprite2D
var point: Vector2

func _setup() -> void:
	agent2D = agent as Node2D
	agentSprite = agent2D.get_node("%Sprite") as Sprite2D

func _enter() -> void:
	point = blackboard.get_var("RandomLocation") as Vector2
	if (agent2D.global_position.direction_to(point).x < 0):
		agentSprite.flip_h = true
	else:
		agentSprite.flip_h = false

func _tick(delta: float) -> Status:
	var speed: float = agent2D.get("speed") as float
	var moveScalar: float = speed * delta

	var remainingDistance: float = agent2D.global_position.distance_to(point)
	if (remainingDistance < moveScalar):
		agent2D.global_position = point
		return SUCCESS

	var moveVector: Vector2 = agent2D.global_position.direction_to(point) * moveScalar

	agent2D.global_position += moveVector
	return RUNNING
