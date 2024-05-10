using UnityEngine;
using System.Collections;

public class MoveObjectLeft : MonoBehaviour
{
    public float rotationSpeed = 30f; // Rotation speed in degrees per second
    public Vector3 rotationAxis = Vector3.up; // The axis around which the object will rotate

    void Update()
    {
        // Rotate the object around the specified axis at the specified speed
        transform.Rotate(rotationAxis, rotationSpeed * Time.deltaTime);
    }
}
