using UnityEngine;

public class BoundaryDestroyer : MonoBehaviour
{
    public RocketCollision rocketCollisionScript;
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Rocket"))  // Make sure your rocket GameObject has the tag "Rocket"
        {
            if (rocketCollisionScript != null)
            {
                rocketCollisionScript.UponCollision();  // Call the method from OtherScript
            }
        }
    }
}
