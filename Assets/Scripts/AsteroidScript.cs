using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    public float amplitude = 0.5f;   // How much the object moves up and down
    public float frequency = 1f;     // Speed of the levitation

    private Vector2 startPosition;

    void Start()
    {
        // Store the starting position of the object
        startPosition = transform.position;
    }

    void Update()
    {
        // Calculate the new position based on the sine wave
        float newY = startPosition.y + Mathf.Sin(Time.time * frequency) * amplitude;
        
        // Apply the new position to the object
        transform.position = new Vector2(transform.position.x, newY);
    }
}
