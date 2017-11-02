tool
extends Spatial

# class member variables go here, for example:
# var a = 2
# var b = "textvar"

var moveDir = Vector3(0,0,0)
var targetDir = Vector3(0,0,0)

func _ready():
	# Called every time the node is added to the scene.
	# Initialization here
	set_process(true)
	set_fixed_process(true)

func _process(delta):
	moveDir = get_input_dir()
	
func _fixed_process(delta):
	doMove(moveDir, delta)
	doRot(moveDir, delta)
	
	
func doMove(moveDir, delta):
		#var node = get_node("Character")
		move(moveDir * delta)

func doRot(lookDir, delta):
	var node = get_node("Mesh")
	var actualDir = targetDir.linear_interpolate(lookDir, delta)
	node.look_at(node.get_transform().origin - actualDir, Vector3(0, 1, 0))
	targetDir = actualDir
	
func get_input_dir():
	var dir = Vector3(0, 0, 0)
	if(Input.is_action_pressed("move_north")):
		dir.z += 1
	if(Input.is_action_pressed("move_south")):
		dir.z -= 1
	if(Input.is_action_pressed("move_east")):
		dir.x += 1
	if(Input.is_action_pressed("move_west")):
		dir.x -= 1
	return dir