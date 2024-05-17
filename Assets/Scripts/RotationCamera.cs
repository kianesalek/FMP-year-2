using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationCamera : MonoBehaviour
{
    public float rotationSpeed = 10f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float rotationAmount = rotationSpeed * Time.deltaTime;

        // Apply the rotation to the camera's transform
        transform.Rotate(Vector3.up, rotationAmount);
    }
}
