using UnityEngine;

public class CameraSquareMovement : MonoBehaviour
{
    // Variables to control the speed of the camera's movement and the size of the square
    public float speed = 1f;
    public float squareSize = 10f;

    // Initial position of the camera
    private Vector3 startPosition;

    // Variables to control the state machine
    private Vector3 targetPosition;
    private int currentDirection = 0;
    private float moveProgress = 0f;

    // Possible directions for the camera movement
    private readonly Vector3[] directions = new Vector3[]
    {
        new Vector3(-1, 0, 0), // Left
        new Vector3(0, 1, 0),  // Up
        new Vector3(1, 0, 0),  // Right
        new Vector3(0, -1, 0)  // Down
    };

    // Start is called before the first frame update
    void Start()
    {
        // Store the initial position of the camera
        startPosition = transform.position;

        // Calculate the initial target position
        targetPosition = startPosition + directions[currentDirection] * squareSize;
    }

    // Update is called once per frame
    void Update()
    {
        // Move the camera towards the target position
        moveProgress += Time.deltaTime * speed;
        transform.position = Vector3.Lerp(transform.position, targetPosition, moveProgress);

        // Check if the camera is close enough to the target position
        if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
        {
            // Move to the next direction
            currentDirection = (currentDirection + 1) % directions.Length;

            // Reset move progress
            moveProgress = 0f;

            // Calculate the new target position
            targetPosition = transform.position + directions[currentDirection] * squareSize;
        }
    }
}
