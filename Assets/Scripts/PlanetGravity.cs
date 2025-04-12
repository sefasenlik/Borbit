using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGravity : MonoBehaviour{
    // Create a LayerMask to ignore the "Boundary" layer
    public LayerMask layerMask;
    private Camera mainCamera;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] int earthGravityCoefficient;
    [SerializeField] int venusGravityCoefficient;
    [SerializeField] int rotationInhibitor;

    void Start()
    {
        mainCamera = Camera.main;
    }

    bool pull = false;

    // Update is called once per frame
    void Update(){

        // Check if the mouse button is pressed down and the cursor is over the Planet object
        if (Input.GetMouseButtonDown(0)){ pull = true; }        
        if (Input.GetMouseButtonUp(0)){ pull = false; }      

        if (pull){
            GameObject earth = GameObject.Find("Earth");
            GameObject venus = GameObject.Find("Venus");
            GameObject hitPlanet = null;
            int planetGravityCoefficient = 0;

            // Convert the mouse position to world coordinates
            Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            // Perform a raycast at the mouse position
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, Mathf.Infinity, ~layerMask);
            
            // Check if the raycast hit this object's CircleCollider2D
            if (hit.collider != null)
            {    
                if (earth != null && hit.collider.gameObject == earth){
                    hitPlanet = earth;
                    planetGravityCoefficient = earthGravityCoefficient;
                } else if (venus != null && hit.collider.gameObject == venus){
                    hitPlanet = venus;
                    planetGravityCoefficient = venusGravityCoefficient;
                } else {
                    Debug.LogError("Planet object not found!");
                }     
            }
            
            // Check if the raycast hit this object's CircleCollider2D
            if (hitPlanet != null)
            {        
                Vector2 delta = (Vector2)hitPlanet.transform.position - rb.position;
                Vector2 forceVector = delta / delta.sqrMagnitude * planetGravityCoefficient;

                // Apply gravitational force to pull the rocket towards Earth
                rb.AddForce(forceVector * Time.deltaTime);

                // Rotate the rocket to face the Earth
                float angle = Mathf.Atan2(delta.y, delta.x) * Mathf.Rad2Deg - 90f;
                rb.rotation = Mathf.LerpAngle(rb.rotation, angle, Time.deltaTime * forceVector.magnitude/rotationInhibitor); // Adjust the rotationCoefficient to change the rotation speed
            }
        }
    }
}
