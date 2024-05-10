using UnityEngine;

public class RotateObject : MonoBehaviour
{
    private float rotationAngle = 130f;
    private float duration = 3f;
    private float elapsedTime = 0f;
    private Quaternion startRotation;
    private Quaternion endRotation;

    void Start()
    {
        startRotation = transform.rotation;
        endRotation = transform.rotation * Quaternion.Euler(0, rotationAngle, 0);
    }

    void Update()
    {
        if (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration;
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, t);
        }
    }
}
