using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    public float moveSpeed;
    [SerializeField] private Rigidbody2D rb;

    private SpriteRenderer spriteRenderer; // Store the SpriteRenderer for RocketGlow

    void Start()
    {
        // Get the RocketGlow object and its SpriteRenderer
        GameObject glow = GameObject.Find("RocketGlow");

        if (glow != null){
            spriteRenderer = glow.GetComponent<SpriteRenderer>();
        } else {
            Debug.LogError("RocketGlow object not found!");
        }
    }

    void Update()
    {
        // Rocket's movement
        Vector2 movementDirection = transform.up; // Rocket's forward direction
        rb.velocity = movementDirection * moveSpeed;

        // Add slight noise to the rocket movement
        rb.position = rb.position + new Vector2(Random.Range(-0.005f, 0.005f), Random.Range(-0.005f, 0.005f));

        // Make sure the spriteRenderer is not null
        if (spriteRenderer != null)
        {
            float alpha = Random.Range(0f, 1f);

            // Get the current color of the RocketGlow
            Color currentColor = spriteRenderer.color;

            // Update the alpha (transparency) value
            currentColor.a = alpha;

            // Apply the new color back to the sprite
            spriteRenderer.color = currentColor;
        }
    }
}
