tool
extends Spatial

# class member variables go here, for example:
# var a = 2
# var b = "textvar"

func _ready():
	# Called every time the node is added to the scene.
	# Initialization here
	set_process(true)

func _process(delta):
	var moveDir = get_input_dir()
	get_node("Character").translate(Vector3(moveDir.x, 0, moveDir.y) * delta)
	
	
	
	
func get_input_dir():
	var dir = Vector2(0, 0)
	if(Input.is_action_pressed("move_north")):
		dir.y += 1
	if(Input.is_action_pressed("move_south")):
		dir.y -= 1
	if(Input.is_action_pressed("move_east")):
		dir.x += 1
	if(Input.is_action_pressed("move_west")):
		dir.x -= 1
	return dir