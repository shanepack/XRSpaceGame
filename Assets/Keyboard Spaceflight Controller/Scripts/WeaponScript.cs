// // using UnityEngine;
// // using UnityEngine.InputSystem;
// // using UnityEngine.InputSystem.Controls;
// // using System.Linq;

// // public class WeaponScript : MonoBehaviour
// // {
// // 	public GameObject[] shotSpawns;
// // 	public GameObject shot;

// // 	void Update()
// // 	{
// // 		bool triggerPressed = false;

// // 		// Get all connected devices
// // 		var devices = InputSystem.devices;

// // 		foreach (var device in devices)
// // 		{
// // 			// Check if the device is an XR controller
// // 			if (device is UnityEngine.InputSystem.XR.XRController)
// // 			{
// // 				// Check if the device is the left or right hand controller
// // 				if (device.usages.Contains(UnityEngine.InputSystem.CommonUsages.LeftHand) ||
// // 					device.usages.Contains(UnityEngine.InputSystem.CommonUsages.RightHand))
// // 				{
// // 					// Attempt to get the trigger control (usually an AxisControl)
// // 					var triggerControl = device.TryGetChildControl<AxisControl>("trigger");

// // 					if (triggerControl != null)
// // 					{
// // 						// Read the trigger value
// // 						float triggerValue = triggerControl.ReadValue();

// // 						// Check if the trigger is pressed beyond a threshold
// // 						if (triggerValue > 0.1f) // Adjust the threshold as needed
// // 						{
// // 							triggerPressed = true;
// // 							break; // Exit the loop once a trigger press is detected
// // 						}
// // 					}
// // 				}
// // 			}
// // 		}

// // 		// If the trigger is pressed, fire the weapon
// // 		if (triggerPressed)
// // 		{
// // 			foreach (GameObject ss in shotSpawns)
// // 			{
// // 				Instantiate(shot, ss.transform.position, ss.transform.rotation);
// // 			}
// // 		}
// // 	}
// // }

// using UnityEngine;
// using UnityEngine.InputSystem;
// using UnityEngine.InputSystem.Controls;
// using System.Linq;

// public class WeaponScript : MonoBehaviour
// {
// 	public GameObject[] shotSpawns;
// 	public GameObject shot;

// 	public float fireRate = 0.2f; // Time between shots in seconds
// 	private float nextFireTime = 0f; // Time when the next shot can be fired

// 	void Update()
// 	{
// 		bool triggerPressed = false;

// 		// Get all connected devices
// 		var devices = InputSystem.devices;

// 		foreach (var device in devices)
// 		{
// 			// Check if the device is an XR controller
// 			if (device is UnityEngine.InputSystem.XR.XRController)
// 			{
// 				// Check if the device is the left or right hand controller
// 				if (device.usages.Contains(UnityEngine.InputSystem.CommonUsages.LeftHand) ||
// 					device.usages.Contains(UnityEngine.InputSystem.CommonUsages.RightHand))
// 				{
// 					// Attempt to get the trigger control (usually an AxisControl)
// 					var triggerControl = device.TryGetChildControl<AxisControl>("trigger");

// 					if (triggerControl != null)
// 					{
// 						// Read the trigger value
// 						float triggerValue = triggerControl.ReadValue();

// 						// Check if the trigger is pressed beyond a threshold
// 						if (triggerValue > 0.1f) // Adjust the threshold as needed
// 						{
// 							triggerPressed = true;
// 							break; // Exit the loop once a trigger press is detected
// 						}
// 					}
// 				}
// 			}
// 		}

// 		// If the trigger is pressed and the cooldown period has elapsed, fire the weapon
// 		if (triggerPressed && Time.time >= nextFireTime)
// 		{
// 			nextFireTime = Time.time + fireRate; // Set the time for the next allowable shot

// 			foreach (GameObject ss in shotSpawns)
// 			{
// 				Instantiate(shot, ss.transform.position, ss.transform.rotation);
// 			}
// 		}
// 	}
// }

using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using System.Linq;

public class WeaponScript : MonoBehaviour
{
	public GameObject[] shotSpawns;
	public GameObject shot;

	public float fireRate = 0.2f; // Time between shots in seconds
	private float nextFireTime = 0f; // Time when the next shot can be fired

	private AudioSource audioSource; // Reference to the AudioSource component
	private bool isTriggerHeld = false; // To track the trigger state

	void Start()
	{
		// Get the AudioSource component attached to the weapon
		audioSource = GetComponent<AudioSource>();
		if (audioSource == null)
		{
			Debug.LogError("AudioSource component missing on weapon. Please add one.");
		}
	}

	void Update()
	{
		bool triggerPressed = false;

		// Get all connected devices
		var devices = InputSystem.devices;

		foreach (var device in devices)
		{
			// Check if the device is an XR controller
			if (device is UnityEngine.InputSystem.XR.XRController)
			{
				// Check if the device is the left or right hand controller
				if (device.usages.Contains(UnityEngine.InputSystem.CommonUsages.LeftHand) ||
					device.usages.Contains(UnityEngine.InputSystem.CommonUsages.RightHand))
				{
					// Attempt to get the trigger control (usually an AxisControl)
					var triggerControl = device.TryGetChildControl<AxisControl>("trigger");

					if (triggerControl != null)
					{
						// Read the trigger value
						float triggerValue = triggerControl.ReadValue();

						// Check if the trigger is pressed beyond a threshold
						if (triggerValue > 0.1f) // Adjust the threshold as needed
						{
							triggerPressed = true;
							break; // Exit the loop once a trigger press is detected
						}
					}
				}
			}
		}

		// Handle audio playback based on trigger state
		if (triggerPressed && !isTriggerHeld)
		{
			// Trigger just pressed
			isTriggerHeld = true;

			// Start playing the gunfire audio
			if (audioSource != null && !audioSource.isPlaying)
			{
				audioSource.Play();
			}
		}
		else if (!triggerPressed && isTriggerHeld)
		{
			// Trigger just released
			isTriggerHeld = false;

			// Stop playing the gunfire audio
			if (audioSource != null && audioSource.isPlaying)
			{
				audioSource.Stop();
			}
		}

		// If the trigger is pressed and the cooldown period has elapsed, fire the weapon
		if (triggerPressed && Time.time >= nextFireTime)
		{
			nextFireTime = Time.time + fireRate; // Set the time for the next allowable shot

			foreach (GameObject ss in shotSpawns)
			{
				Instantiate(shot, ss.transform.position, ss.transform.rotation);
			}
		}
	}
}

