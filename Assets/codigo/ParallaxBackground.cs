using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    public Transform[] backgrounds;         // Array of all the background objects to be parallaxed
    public float parallaxScale = 0.5f;      // The proportion of the camera's movement to move the backgrounds by
    public float parallaxReductionFactor = 0.5f;   // How much less each successive layer should move (0-1)
    public float smoothing = 1f;            // How smooth the parallax effect should be

    private Transform cam;                  // Reference to the main camera's transform
    private Vector3 previousCamPos;         // The position of the camera in the previous frame

    void Start()
    {
        // Set up the camera reference
        cam = Camera.main.transform;

        // Set the previous frame's camera position to the current position
        previousCamPos = cam.position;
    }

    void Update()
    {
        // Calculate the parallax for each background layer
        for (int i = 0; i < backgrounds.Length; i++)
        {
            float parallax = (previousCamPos.x - cam.position.x) * parallaxScale * (i * parallaxReductionFactor + 1);
            float backgroundTargetPosX = backgrounds[i].position.x + parallax;

            // Create a target position which is the background's current position but moved to the right
            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

            // Lerp the background's position towards the target position to smooth the parallax effect
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
        }

        // Set the previous frame's camera position to the current position
        previousCamPos = cam.position;
    }
}
