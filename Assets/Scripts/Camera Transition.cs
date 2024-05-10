using UnityEngine;
using System.Collections;
public class CameraTransition : MonoBehaviour
{
    public Camera[] cameras; // Array of cameras to transition between
    public float transitionDuration = 2f; // Duration of the transition in seconds
    public AnimationCurve transitionCurve; // Animation curve for easing effect

    private int currentCameraIndex = 0; // Index of the current camera

    void Start()
    {
        // Set all cameras except the first one to be inactive
        for (int i = 1; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(false);
        }

        // Set the first camera as active
        cameras[0].gameObject.SetActive(true);
    }

    // Method to transition to the next camera
    public void TransitionToNextCamera()
    {
        // Determine the next camera index
        int nextCameraIndex = (currentCameraIndex + 1) % cameras.Length;

        // Start the transition coroutine
        StartCoroutine(TransitionBetweenCameras(cameras[currentCameraIndex], cameras[nextCameraIndex]));

        // Update the current camera index
        currentCameraIndex = nextCameraIndex;
    }

    // Coroutine to transition smoothly between two cameras
    IEnumerator TransitionBetweenCameras(Camera fromCamera, Camera toCamera)
    {
        // Store the initial and final properties of the cameras
        Vector3 initialPosition = fromCamera.transform.position;
        Quaternion initialRotation = fromCamera.transform.rotation;
        float initialFieldOfView = fromCamera.fieldOfView;

        Vector3 finalPosition = toCamera.transform.position;
        Quaternion finalRotation = toCamera.transform.rotation;
        float finalFieldOfView = toCamera.fieldOfView;

        // Transition over the specified duration
        for (float t = 0; t < transitionDuration; t += Time.deltaTime)
        {
            float normalizedTime = t / transitionDuration;

            // Calculate the ease value using the animation curve
            float easeValue = transitionCurve.Evaluate(normalizedTime);

            // Interpolate position, rotation, and field of view
            fromCamera.transform.position = Vector3.Lerp(initialPosition, finalPosition, easeValue);
            fromCamera.transform.rotation = Quaternion.Slerp(initialRotation, finalRotation, easeValue);
            fromCamera.fieldOfView = Mathf.Lerp(initialFieldOfView, finalFieldOfView, easeValue);

            yield return null; // Wait for the next frame
        }

        // Set the final properties of the from camera to the final properties of the to camera
        fromCamera.transform.position = finalPosition;
        fromCamera.transform.rotation = finalRotation;
        fromCamera.fieldOfView = finalFieldOfView;

        // Activate the target camera and deactivate the current camera
        fromCamera.gameObject.SetActive(false);
        toCamera.gameObject.SetActive(true);
    }
}
