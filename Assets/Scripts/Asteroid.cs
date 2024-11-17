// using UnityEngine;

// public class Asteroid : MonoBehaviour
// {
//     [HideInInspector]
//     public Transform centerObject;   // Reference to the center object

//     public float destroyDistance = 1f;     // Distance at which the asteroid will be destroyed
//     public float rotationSpeed = 100f;     // Maximum rotation speed

//     private Vector3 randomRotationAxis;    // Random axis for spinning

//     // Reference to the explosion particle effect prefab
//     public GameObject explosionEffect;
//     // Reference to the explosion sound clip
//     public AudioClip explosionSound;

//     void Start()
//     {
//         // Assign a random axis for rotation
//         randomRotationAxis = Random.onUnitSphere;
//     }

//     void Update()
//     {
//         if (centerObject == null)
//         {
//             Debug.LogError("Center Object is not assigned in Asteroid script.");
//             return;
//         }

//         // Rotate the asteroid around the random axis
//         transform.Rotate(randomRotationAxis * rotationSpeed * Time.deltaTime);

//         // Check the distance between the asteroid and the center object
//         float distanceToCenter = Vector3.Distance(transform.position, centerObject.position);

//         if (distanceToCenter <= destroyDistance)
//         {
//             // Play explosion effect at asteroid's position
//             if (explosionEffect != null)
//             {
//                 GameObject asteroidExplosion = Instantiate(explosionEffect, transform.position, Quaternion.identity);
//                 Destroy(asteroidExplosion, 2f); // Adjust the duration based on your particle effect
//             }

//             // Play explosion sound at asteroid's position
//             if (explosionSound != null)
//             {
//                 AudioSource.PlayClipAtPoint(explosionSound, transform.position);
//             }

//             // Play explosion effect at center object's position
//             if (explosionEffect != null)
//             {
//                 GameObject centerExplosion = Instantiate(explosionEffect, centerObject.position, Quaternion.identity);
//                 Destroy(centerExplosion, 2f); // Adjust the duration based on your particle effect
//             }

//             // Play explosion sound at center object's position
//             if (explosionSound != null)
//             {
//                 AudioSource.PlayClipAtPoint(explosionSound, centerObject.position);
//             }

//             // Destroy the center object
//             Destroy(centerObject.gameObject);

//             // Destroy the asteroid
//             Destroy(gameObject);
//         }
//     }
// }

using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [HideInInspector]
    public Transform centerObject;   // Reference to the center object

    public float destroyDistance = 1f;     // Distance at which the asteroid will be destroyed
    public float rotationSpeed = 100f;     // Maximum rotation speed

    private Vector3 randomRotationAxis;    // Random axis for spinning

    // Reference to the explosion particle effect prefab
    public GameObject explosionEffect;
    // Reference to the explosion sound clip
    public AudioClip explosionSound;

    void Start()
    {
        // Assign a random axis for rotation
        randomRotationAxis = Random.onUnitSphere;
    }

    void Update()
    {
        Vector3 centerPosition;

        if (centerObject == null)
        {
            // Use the fallback coordinates
            centerPosition = new Vector3(0f, 1.5f, 0.57f);
            // Optional: Log a warning instead of an error
            Debug.LogWarning("Center Object is not assigned. Using fallback position.");
        }
        else
        {
            // Use the center object's position
            centerPosition = centerObject.position;
        }

        // Rotate the asteroid around the random axis
        transform.Rotate(randomRotationAxis * rotationSpeed * Time.deltaTime);

        // Check the distance between the asteroid and the center position
        float distanceToCenter = Vector3.Distance(transform.position, centerPosition);

        if (distanceToCenter <= destroyDistance)
        {
            // Play explosion effect at asteroid's position
            if (explosionEffect != null)
            {
                GameObject asteroidExplosion = Instantiate(explosionEffect, transform.position, Quaternion.identity);
                Destroy(asteroidExplosion, 2f); // Adjust the duration based on your particle effect
            }

            // Play explosion sound at asteroid's position
            if (explosionSound != null)
            {
                AudioSource.PlayClipAtPoint(explosionSound, transform.position);
            }

            // Play explosion effect at center position
            if (explosionEffect != null)
            {
                GameObject centerExplosion = Instantiate(explosionEffect, centerPosition, Quaternion.identity);
                Destroy(centerExplosion, 2f); // Adjust the duration based on your particle effect
            }

            // Play explosion sound at center position
            if (explosionSound != null)
            {
                AudioSource.PlayClipAtPoint(explosionSound, centerPosition);
            }

            // Destroy the center object if it exists
            if (centerObject != null)
            {
                Destroy(centerObject.gameObject);
            }

            // Destroy the asteroid
            Destroy(gameObject);
        }
    }
}

