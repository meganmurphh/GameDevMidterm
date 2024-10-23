using UnityEngine;

public class FollowBullet : MonoBehaviour
{
    public Transform bulletTransform;
    public Vector3 offset = new Vector3(0, 1.5f, 0); // Adjust the offset as needed

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (bulletTransform != null)
        {
            // Make the text follow the bullet with the specified offset
            transform.position = bulletTransform.position + offset;

            // Make the text face the camera
            if (mainCamera != null)
            {
                transform.LookAt(mainCamera.transform);
                transform.Rotate(0, 180, 0); // Optional: Rotate to face camera correctly
            }
        }
    }
}
