using UnityEngine;
using UnityEngine.UI;

public class CollisionTest : MonoBehaviour
{
    private Text crateText;
    public int crateValue;

    public float fallSpeed = 2f;

    void Start()
    {
        crateText = GetComponentInChildren<Text>();
        UpdateCrateText();
    }

    public void UpdateCrateText()
    {
        if (crateText != null)
        {
            crateText.text = crateValue.ToString();
            Debug.Log("Crate value set to: " + crateValue);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided with: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Bullet")) 
        {
            Debug.Log("Bullet hit crate!");

            Text bulletText = collision.gameObject.GetComponentInChildren<Text>();
            if (bulletText != null && int.TryParse(bulletText.text, out int bulletValue))
            {
                crateValue -= bulletValue;
                Debug.Log("Crate value after hit: " + crateValue);

                crateText.text = crateValue.ToString();

                if (crateValue == 0)
                {
                    Debug.Log("Crate destroyed");
                    Destroy(gameObject);
                }
                if (crateValue < 0)
                {
                    Debug.Log("Negative Value");
                    Destroy(gameObject);
                }
            }
            else
            {
                Debug.LogError("Bullet value could not be parsed from bullet text.");
            }

            Destroy(collision.gameObject);
        }
    }

    void FixedUpdate()
    {
        Rigidbody crateRb = GetComponent<Rigidbody>();
        if (crateRb != null && !crateRb.isKinematic)
        {
            crateRb.velocity = new Vector3(crateRb.velocity.x, -fallSpeed, crateRb.velocity.z);
        }
    }
}
