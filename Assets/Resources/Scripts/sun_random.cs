using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeSun : MonoBehaviour
{
    public Vector3 minPosition;
    public Vector3 maxPosition;
    public Vector3 minRotation;
    public Vector3 maxRotation;
    public float movementSpeed = 1.0f;
    public float rotationSpeed = 30.0f; // Degrees per second

    private Vector3 initialPosition;
    private Vector3 initialRotation;

    void Start()
    {
        // Store the initial position and rotation of the sun.
        initialPosition = transform.position;
        initialRotation = transform.eulerAngles;
    }

    void Update()
    {
        // Calculate the new position and rotation based on time.
        float t = Mathf.PingPong(Time.time * movementSpeed, 1.0f);
        Vector3 newPosition = Vector3.Lerp(minPosition, maxPosition, t);
        Vector3 newRotation = Vector3.Lerp(minRotation, maxRotation, t);

        // Apply the new position and rotation to the sun.
        transform.position = newPosition;
        transform.eulerAngles = newRotation;
    }
}
