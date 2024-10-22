using UnityEngine;

public class CannonController : MonoBehaviour
{
    public float rotationSpeed = 3f;
    public float minAngle = -45f;
    public float maxAngle = 20f;  

    private float currentAngle = 0f; 

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");

        currentAngle -= mouseX * rotationSpeed;

        currentAngle = Mathf.Clamp(currentAngle, minAngle, maxAngle);

        transform.localEulerAngles = new Vector3(0, 0, currentAngle);
    }
}
