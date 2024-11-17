using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceflight : MonoBehaviour {


	public Transform hull; //A reference to the entire ship's hull (must be nested inside PlayerShip object) to be titled left and right locally as the ship turns.
	public float maxTilt = 20f; //Maximum tilt of above behavior (turning to the right, the hull will yaw X degrees to the right). Set zero to remove behavior.

	//This script causes the ship to try to fly forward at a target speed, using a max linear acceleration to change velocity when turning,
	//recovering from a collision, or speeding up. It also tries to recover from spinouts, and do regular turning,
	//both using a similar max angular acceleration parameter.
	public float MaxSpeed = 40f; //Forward speed that is maintained when at full thrust. (See thrusting var below)
	public float MaxAngularAcceleration = 30f; //Used for turning and spinout recovery
	public float MaxAcceleration = 4f; //Acceleration used to change speed, and to change momentum's direction when turning.
	//Units of above: meters/sec, degrees/sec/sec, meters/sec/sec.

	public float TurnFactor = 1f; //Affects turning speed.
	//2f to double, 1f for default, 0.33f to turn slower, 0 do disable, and -1f to invert both X and Y axes.

	internal float ControlHorizontal; //Fixed update assigns horizonal control axis to this each frame, for player controlled. 
	internal float ControlVertical; //Same thought; vertical axis.
	//If building an AI from this script, modify these two variables some other way.
	internal float ControlThrust = 1f; //Factor of max speed the flighter will accelerate to. Currently, value fixed at 1.
	//If you want a ship that can slow down and speed up by player control, modify this value with another script.
	//When it is +1f, fighter tries to fly forward at max speed.
	//	+2f would override max speed and fly at double.
	//	0.33f would slow forward speed to 1/3 max speed.
	//	0f would slow the ship to a complete halt.
	//	-0.33f would fly the ship backwards at 1/3 speed.
	//These changes would take a second or so to take effect, because really what is happening is that 'thrust' sets the fighter's INTENDED speed,
	//which is then approached using acceleration (or deceleration), capped at magnitude MaxAcceleration.

	//Fighter also loses mobility for a few seconds after a collision. Specifically, its apparent maxAccelaration and maxAngularAcceleration are reduced.
	internal float stunned = 0f; //1f means thrust and turn disabled completely, like after collisions. 0f means no reduction.
	//0.5f would means acceleration is at exactly half power at the moment. See the STUN CODE in FixedUpdate for details on duration
	//To disable stun on collide, comment out the only line in function OnCollisionEnter

	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody> ();
	}
		
	void FixedUpdate () {

		//STUN CODE
		//At any moment, if stunned is greater than zero, ship mobility is reduced. This code handles the decay of that variable to zero.
		if (stunned > 1f)
			stunned = 1f; //Stun is never above 1.
		else if (stunned > 0.85f)
			stunned -= Time.fixedDeltaTime * 0.05f; //3 seconds nearly completely disabled (decaying from 1.0f to 0.85f)
		else if (stunned > 0f)
			stunned -= Time.fixedDeltaTime * 0.5f; //2 more seconds, only marginally slowed (decaying from 0.85f to 0f)
		else
			stunned = 0f; //Stun is never lower than zero.



		//IF PLAYER
		ControlHorizontal = Input.GetAxis ("Horizontal");
		ControlVertical = Input.GetAxis ("Vertical");
		//ELSE ASSIGN VIA AI


		//ACCELERATION CODE.
		//To those familiar with vector math, accelaration simply follows the direction of (desired velocity minus current)
		//and is capped at a magnitude of MaxAcceleration.
		//So, acceleration can be in any direction and is not necessarily forward as the engine flames might imply.
		//For example, when turning right, acceleration is purely to the right (centripetal acceleration - nothing to do with the ship rotating, which is in the next code group)
        Vector3 vDiff = transform.up * MaxSpeed * ControlThrust - rb.velocity; //Difference between current velocity and intended velocity.
		if (vDiff.magnitude > MaxAcceleration * (1f - stunned))
			vDiff *= MaxAcceleration * (1f - stunned) / vDiff.magnitude;
		rb.AddForce (vDiff , ForceMode.VelocityChange);

		//TURNING CODE.
		//Note on the math here: Turn speed (target/intended angular velocity) is "TurnFactor" radians per second.
		//The code below calculates the needed angular acceleration needed to reach that turning speed, then applies
		//angular acceleration in that direction, capped at max angular acceleration.
		//Generally, max angular acceleration is more than sufficient to reach the desired turn speed instantly, so TurnFactor is the limiting factor.
		//MaxAngularAcceleration is, however, the limiting factor in spinout correction, especially when working at reduced power due to stun.
		Vector3 avdiff = -1 * (TurnFactor * (transform.forward * ControlHorizontal + transform.right * ControlVertical) + rb.angularVelocity); //Difference between current angular velocity and intended.
        float mag = avdiff.magnitude;
		avdiff.Normalize (); //avdiff is now avDIRECTION. Magnitude is 1.
		rb.AddTorque (avdiff * Mathf.Clamp (mag, 0, MaxAngularAcceleration * Time.fixedDeltaTime  * (1f - stunned)), ForceMode.VelocityChange);

		//YAW CODE.
		//Visually tilts the hull left and right when turning those directions. Absolutely no effect on overall motion.
		hull.localRotation = Quaternion.Euler (0f, ControlHorizontal * -1f * maxTilt, 0f);
	}

	void OnCollisionEnter()
	{
		stunned = 1f;
	}
}
