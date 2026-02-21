using UnityEngine;

public class PlayerBoundary : MonoBehaviour
{
    public float minX, maxX;
    public float minZ, maxZ; // Use Y for 2D or vertical boundaries

    void Update()
    {
        // Clamp the player's position within the defined boundaries
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, minX, maxX),
            transform.position.y,
            Mathf.Clamp(transform.position.z, minZ, maxZ)
        );
    }
}
