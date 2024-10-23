using UnityEngine;

public class FollowBullet : MonoBehaviour
{
    public Transform bulletTransform;
    public Vector3 offset = new Vector3(0, 1.5f, 0);

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (bulletTransform != null)
        {
            transform.position = bulletTransform.position + offset;

            transform.LookAt(transform.position + mainCamera.transform.rotation * Vector3.forward,
                             mainCamera.transform.rotation * Vector3.up);

            if (!IsInView())
            {
                Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private bool IsInView()
    {
        Vector3 screenPoint = mainCamera.WorldToViewportPoint(transform.position);
        bool isInView = screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;
        return isInView;
    }
}
