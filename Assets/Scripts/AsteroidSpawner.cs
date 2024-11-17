// using System.Collections;
// using UnityEngine;

// public class AsteroidSpawner : MonoBehaviour
// {
//     public GameObject[] Asteroids;
//     public float spawnInterval = 10.0f;    // Time interval between spawns
//     public float minSpeed = 5f;            // Minimum speed of asteroids
//     public float maxSpeed = 15f;           // Maximum speed of asteroids
//     public float spawnRadius = 100f;       // Radius of the spawning sphere
//     public float minSpawnDistance = 50f;   // Minimum distance from the center object

//     public Transform centerObject;         // The center object asteroids move towards

//     void Start()
//     {
//         if (centerObject == null)
//         {
//             Debug.LogError("Center Object is not assigned in AsteroidSpawner script.");
//             return;
//         }
//         StartCoroutine(SpawnAsteroids());
//     }

//     private IEnumerator SpawnAsteroids()
//     {
//         while (true)
//         {
//             Vector3 spawnPosition = RandomPicker();
//             Debug.Log("Asteroid spawned at: " + spawnPosition);
//             yield return new WaitForSeconds(spawnInterval);
//         }
//     }

//     public Vector3 RandomPicker()
//     {
//         if (Asteroids == null || Asteroids.Length == 0)
//         {
//             Debug.LogError("Asteroids array is empty. Please assign asteroid prefabs.");
//             return Vector3.zero;
//         }

//         int randomNumber = Random.Range(0, Asteroids.Length);

//         Vector3 spawnPosition = GetRandomSpawnPosition();

//         // Instantiate asteroid at the correct spawn position with random rotation
//         GameObject asteroid = Instantiate(
//             Asteroids[randomNumber],
//             spawnPosition,
//             Random.rotation
//         );

//         Vector3 directionToCenter = (centerObject.position - asteroid.transform.position).normalized;
//         float speed = Random.Range(minSpeed, maxSpeed);
//         Rigidbody asteroidRigidbody = asteroid.GetComponent<Rigidbody>();

//         // Check if the asteroid has a Rigidbody component
//         if (asteroidRigidbody != null)
//         {
//             asteroidRigidbody.velocity = directionToCenter * speed;
//         }
//         else
//         {
//             Debug.LogError("The asteroid prefab is missing a Rigidbody component.");
//         }

//         return spawnPosition;
//     }

//     private Vector3 GetRandomSpawnPosition()
//     {
//         Vector3 spawnPosition;
//         do
//         {
//             // Generate a random point on the sphere surface around the center object
//             spawnPosition = centerObject.position + Random.onUnitSphere * spawnRadius;
//         } while (Vector3.Distance(spawnPosition, centerObject.position) < minSpawnDistance);

//         return spawnPosition;
//     }

//     // Optional: Visualize the spawn sphere and minimum distance in the editor
//     void OnDrawGizmos()
//     {
//         if (centerObject != null)
//         {
//             Gizmos.color = Color.yellow;
//             Gizmos.DrawWireSphere(centerObject.position, spawnRadius);

//             Gizmos.color = Color.red;
//             Gizmos.DrawWireSphere(centerObject.position, minSpawnDistance);
//         }
//     }
// }

using System.Collections;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject[] Asteroids;
    public float spawnInterval = 10.0f;    // Time interval between spawns
    public float minSpeed = 5f;            // Minimum speed of asteroids
    public float maxSpeed = 15f;           // Maximum speed of asteroids
    public float spawnRadius = 100f;       // Radius of the spawning sphere
    public float minSpawnDistance = 50f;   // Minimum distance from the center object

    public Transform centerObject;         // The center object asteroids move towards

    void Start()
    {
        if (centerObject == null)
        {
            Debug.LogError("Center Object is not assigned in AsteroidSpawner script.");
            return;
        }
        StartCoroutine(SpawnAsteroids());
    }

    private IEnumerator SpawnAsteroids()
    {
        while (true)
        {
            Vector3 spawnPosition = RandomPicker();
            Debug.Log("Asteroid spawned at: " + spawnPosition);
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    public Vector3 RandomPicker()
    {
        if (Asteroids == null || Asteroids.Length == 0)
        {
            Debug.LogError("Asteroids array is empty. Please assign asteroid prefabs.");
            return Vector3.zero;
        }

        int randomNumber = Random.Range(0, Asteroids.Length);

        Vector3 spawnPosition = GetRandomSpawnPosition();

        // Instantiate asteroid at the correct spawn position with random rotation
        GameObject asteroid = Instantiate(
            Asteroids[randomNumber],
            spawnPosition,
            Random.rotation
        );

        // Assign the center object to the asteroid's script
        Asteroid asteroidScript = asteroid.GetComponent<Asteroid>();
        if (asteroidScript != null)
        {
            asteroidScript.centerObject = centerObject;
            asteroidScript.destroyDistance = 1f; // Adjust as needed
        }
        else
        {
            Debug.LogError("The asteroid prefab is missing the Asteroid script.");
        }

        Vector3 directionToCenter = (centerObject.position - asteroid.transform.position).normalized;
        float speed = Random.Range(minSpeed, maxSpeed);
        Rigidbody asteroidRigidbody = asteroid.GetComponent<Rigidbody>();

        // Check if the asteroid has a Rigidbody component
        if (asteroidRigidbody != null)
        {
            asteroidRigidbody.velocity = directionToCenter * speed;
        }
        else
        {
            Debug.LogError("The asteroid prefab is missing a Rigidbody component.");
        }

        return spawnPosition;
    }

    private Vector3 GetRandomSpawnPosition()
    {
        Vector3 spawnPosition;
        do
        {
            // Generate a random point on the sphere surface around the center object
            spawnPosition = centerObject.position + Random.onUnitSphere * spawnRadius;
        } while (Vector3.Distance(spawnPosition, centerObject.position) < minSpawnDistance);

        return spawnPosition;
    }

    // Optional: Visualize the spawn sphere and minimum distance in the editor
    void OnDrawGizmos()
    {
        if (centerObject != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(centerObject.position, spawnRadius);

            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(centerObject.position, minSpawnDistance);
        }
    }
}

