DOCUMENTATION FOR KEYBOARD SPACEFLIGHT CONTROLLER BY MAXRAZE
Contact: amoser.pk@gmail.com
------------------------------------------------------------------------------------------

Setup A: Test the demo

1) Load up the Demo scene in the Scenes folder, and play it in the editor.

------------------------------------------------------------------------------------------

Setup B: Quickstart using the provided ship, in your own scene.

1) Locate the PlayerShip prefab in the Prefabs folder, and drag it anywhere in your scene.

2) If your scene already had a camera, make sure the Camera inside the playership will be used when you press play.

3) Play the scene. The ship is controlled by the Horizontal and Vertical input axes (defaulting to arrow keys or WASD in unity), with additional weapons functionality on the key Q.

--------------------------------------------------------------------------------------------

Setup C: Using your own ship

1) Create a parent gameobject and two children, which will contain the ship and camera.
	-Start with an empty gameobject. You may name it PlayerShip. Reset its transform.
	-Create a camera as a child of PlayerShip. Reset its transorm.
	-Give the camera an X rotation of -90 and an XYZ position of (0,-20,-6).
	-Create a third gameobject, also a child of PlayerShip, and call it Hull. Reset its transform.

2) Add components to the Hull object.
	-Add the mesh of your ship, either as a component on Hull, or as a child of the Hull gameobject.
	-Include any particles or shot spawns that will turn with the ship inside this Hull object.
	-Reset Hull's transform again, as it is required to have zero position and rotation for the script to work.
		(Note: If your ship mesh needs to be rotated to face forward, you will have to make it a child of Hull
		object, as then it can be rotated freely. The wing and engine pieces of the sample ship were done this
		way.)

3) Add script.
	-Add the Spaceflight script as a component of the PlayerShip object, which is the parent of the other two.
	-Drag the Hull gameobject into the Hull field of the Spaceflight script (above max tilt and max speed).

4) Verify components
	-Verify that there is a Rigidbody component on the PlayerShip object
	-Add a collider to the Hull object if one is not already present.
	-Vefify that the camera object has a camera component, and if the scene has anotother camera present,
		make sure that this camera is set to be used when the scene plays.

5) Test
	-Play the scene. The horizontal and vertical input axes control the ship, defaulting to arrow keys or WASD.

--------------------------------------------------------------------------------------------

Customization:

-Change the ship's mobility with the Max Speed and Turn Factor variables on the Spaceflight script.

-Change the ship's acceleration and spinout recovery with MaxAcceleration and MaxAngularAcceleration.

-Change the ship's yaw when turning left or right with the MaxTilt variable, so set it to zero to disable.

-See comments in the Spaceflight script for instructions on how to modify thrusting and braking using the
	Thrusting variable, and turn the Stun-On-Collision feature off and on.

--------------------------------------------------------------------------------------------

Extra Assets:

The primary asset in this package is the Spaceflight script, but the other assets in the Demo scene may be useful as well. Here is a list of the big ones:

-Sample Ship: Controls flight and camera, but also fires a simple weapon and has multiple particle effects.
	-Hull components: Sample ship is not one mesh, but separate hull, wing, engine, and weapon objects
		which can be rearranged into new ships. Dragging the entire wing objects (mesh, particles, and all)
		from the sample ship onto your own ship saves the hassle of rebuilding them. Same for engine.
	-Particle effects: The energy wing is a particle system, as is the engine flame.
	-Weapon script: This script, which is added to the PlayerShup object, takes Shot prefabs and a ShotSpawn.

-Weapon Bolt Prefab
	-Bolt Script: Makes the projectile fly forward and explode on collisions.
	-Bolt Particles: A combination of three particle systems and a trail to make the bolt visible from
		all angles and at large distances.

-Blast Prefab: A simple explosion effect that is created when a bolt impacts a collider.

-Eyeball Satelites: These were included as scaled up meshes for the ship to fly around in the demo scene.

-Camera fog script: While inactive in the demo scene, this script can set up fog when a scene loads.
	Just attach it to the scene's camera, check the Fog Active variable, adjust fog color, and go.

-Grid skybox: A basic green square grid, used in the demo scene to give the impression of flying inside
	a giant cube (as well as keep track of direction).