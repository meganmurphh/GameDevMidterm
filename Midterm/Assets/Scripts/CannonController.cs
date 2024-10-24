using UnityEngine;

public class CannonController : MonoBehaviour
{
    public float rotationSpeed = 3f;
    public float minAngle = -80f;
    public float maxAngle = 80f;  

    private float currentAngle = 0f; 

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");

        currentAngle -= mouseX * rotationSpeed;

        currentAngle = Mathf.Clamp(currentAngle, minAngle, maxAngle);

        transform.localEulerAngles = new Vector3(0, 0, currentAngle);
    }
}
