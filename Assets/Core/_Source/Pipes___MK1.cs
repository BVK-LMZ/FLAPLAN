    using UnityEngine;  // Import Unity engine for functionality like transforms and cameras.

public class Pipes___MK1 : MonoBehaviour  // Define a class called Pipes___MK1 that inherits from MonoBehaviour (base class for Unity scripts).
{

    /// <summary>
    /// Class Variables
    /// </summary>


    public float _thePipeSpeed = 5f;  // Declare a public variable to control the speed of the pipe's movement, defaulting to 5.
    private float leftEdge;  // Declare a private variable to store the x-position where the pipe will be destroyed.


    /// <summary>
    /// MonoBehaviour
    /// </summary>

    private void Start()  // This method is called when the script is first run.
    {
        // Calculate the x position of the left edge of the screen and subtract 1 to ensure the pipe is fully off-screen.
        // Uses the camera's ScreenToWorldPoint method to convert screen coordinates to world coordinates. 
        // If Camera.main is null (not assigned), default to -10f.
        leftEdge = Camera.main?.ScreenToWorldPoint(Vector3.zero).x - 1f ?? -10f;
    }

    private void Update()  // This method is called once per frame.
    {
        // Move the pipe left by modifying its position. Vector3.left is a shorthand for (-1, 0, 0).
        // Multiply by _thePipeSpeed to set the speed of movement and by Time.deltaTime to account for frame rate independence.
        transform.position += Vector3.left * _thePipeSpeed * Time.deltaTime;

        // Check if the pipe's x position is less than the left edge (off-screen).
        if (transform.position.x < leftEdge)
        {
            // Destroy the pipe when it is off-screen.
            Destroy(gameObject);
        }
    }
}

