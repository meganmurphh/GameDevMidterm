using UnityEngine;

public class CannonController : MonoBehaviour
{
    public float rotationSpeed = 3f;
    public float minAngle = -270f;
    public float maxAngle = 270f;  

    private StartScreenManager startScreenManager;

    private float currentAngle = 0f;

    private void Start()
    {
        startScreenManager = Camera.main.GetComponent<StartScreenManager>();
    }

    void Update()
    {
        if (startScreenManager != null && !startScreenManager.IsStartScreenActive)
        {
            float mouseX = Input.GetAxis("Mouse X");
            currentAngle -= mouseX * rotationSpeed;
            currentAngle = Mathf.Clamp(currentAngle, minAngle, maxAngle);
            transform.localEulerAngles = new Vector3(0, 0, currentAngle);
        }
    }
}
