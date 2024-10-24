using UnityEngine;
using UnityEngine.UI;

public class CollisionTest : MonoBehaviour
{
    private Text crateText;
    private int crateValue; 

    void Start()
    {
        crateText = GetComponentInChildren<Text>();
        if (crateText != null)
        {
            int.TryParse(crateText.text, out crateValue);
            Debug.Log("Initial Crate Value: " + crateValue);
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

                if (crateValue <= 0)
                {
                    Debug.Log("Crate destroyed");
                    Destroy(gameObject);
                }
            }
            else
            {
                Debug.LogError("Bullet value could not be parsed from bullet text.");
            }

            Rigidbody crateRb = GetComponent<Rigidbody>();
            if (crateRb != null)
            {
                crateRb.isKinematic = true; 
            }
        }
    }
}
