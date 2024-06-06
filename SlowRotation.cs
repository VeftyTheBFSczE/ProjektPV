using System.Collections;
using UnityEngine;

public class SlowRotation : MonoBehaviour
{
    public float rotationSpeed = 10f; // Speed of rotation in degrees per second

    void Start()
    {
        // Start the coroutine for rotation
        StartCoroutine(RotateCamera());
    }

    IEnumerator RotateCamera()
    {
        while (true) // Infinite loop for continuous rotation
        {
            // Rotate the camera around the Y axis
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

            yield return null; // Wait for the next frame
        }
    }
}
