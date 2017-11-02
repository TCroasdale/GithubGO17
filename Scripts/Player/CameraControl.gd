extends Spatial

var followSpeed = 4.0
var target = "../Character"

var offset = Vector3(0, 6, -6)

var targNode
func _ready():
	# Called every time the node is added to the scene.
	# Initialization here
	targNode = get_node(target)
	set_process(true)

func _process(delta):
	var targPos = targNode.get_transform().origin
	var currPos = get_transform().origin
	var newPos = currPos.linear_interpolate(targPos + offset, delta * followSpeed)
	set_transform(Transform(Vector3(1,0,0), Vector3(0,1,0), Vector3(0,0,1), newPos))
	look_at(targPos, Vector3(0, 1, 0))