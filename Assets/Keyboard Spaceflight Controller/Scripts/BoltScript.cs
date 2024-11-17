// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class BoltScript : MonoBehaviour {

// 	public float speed = 100f;

// 	public GameObject blast;

// 	public float lifespan = 5f;

// 	// Use this for initialization
// 	void Start () {
// 		Destroy (gameObject, lifespan);
// 	}


// 	void FixedUpdate () {
// 		transform.position += transform.forward * Time.fixedDeltaTime * speed;
// 	}

// 	void OnTriggerEnter(Collider other) {
// 		Instantiate (blast,transform.position,transform.rotation);
// 		Destroy(gameObject);
// 	}
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltScript : MonoBehaviour
{
	public float speed = 100f;
	public GameObject blast;
	public float lifespan = 5f;

	// The amount of damage the bolt will inflict
	public int damage = 1;

	void Start()
	{
		Destroy(gameObject, lifespan);
	}

	void FixedUpdate()
	{
		transform.position += transform.forward * Time.fixedDeltaTime * speed;
	}

	void OnTriggerEnter(Collider other)
	{
		// Instantiate the blast effect
		Instantiate(blast, transform.position, transform.rotation);

		// Try to get the DamageableObject component from the collided object
		DamageableObject damageable = other.GetComponent<DamageableObject>();

		// If the collided object can take damage
		if (damageable != null)
		{
			// Apply damage to the object
			damageable.TakeDamage(damage);
		}

		// Destroy the bolt after collision
		Destroy(gameObject);
	}
}

