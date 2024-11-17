using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [HideInInspector]
    public Transform centerObject;   // Reference to the center object

    public float destroyDistance = 1f; // Distance at which the asteroid will be destroyed
    public float rotationSpeed = 100f; // Maximum rotation speed

    private Vector3 randomRotationAxis; // Random axis for spinning

    void Start()
    {
        // Assign a random axis for rotation
        randomRotationAxis = Random.onUnitSphere;
    }

    void Update()
    {
        if (centerObject == null)
        {
            Debug.LogError("Center Object is not assigned in Asteroid script.");
            return;
        }

        // Rotate the asteroid around the random axis
        transform.Rotate(randomRotationAxis * rotationSpeed * Time.deltaTime);

        // Check the distance between the asteroid and the center object
        float distanceToCenter = Vector3.Distance(transform.position, centerObject.position);

        if (distanceToCenter <= destroyDistance)
        {
            Destroy(gameObject);
        }
    }
}
