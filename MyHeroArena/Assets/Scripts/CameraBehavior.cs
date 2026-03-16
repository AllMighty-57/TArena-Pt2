using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraBehavior : MonoBehaviour
{
   
    // Adjust sensitivity in the Inspector
    public float mouseSensitivity = 100f;

    public Transform Player; // Reference to the parent Player object

    private float xRotation = 0f;

    void Start()
    {
        // Lock the cursor to the center of the screen and hide it
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Get mouse input and multiply by sensitivity
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Vertical rotation (looking up and down)
        xRotation -= mouseY;
        // Clamp the vertical rotation to prevent flipping over (e.g., -90 to 90 degrees)
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Apply vertical rotation to the camera itself
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Horizontal rotation (looking left and right)
        // Apply horizontal rotation to the entire player body
        Player.Rotate(Vector3.up * mouseX);
    }
}