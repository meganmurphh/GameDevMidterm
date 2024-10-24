using UnityEngine;
using UnityEngine.UI;

public class Crate : MonoBehaviour
{
    public int crateValue;
    public Text crateText;
    public float fallSpeed = 10f;

    void Start()
    {
        if (crateText == null)
        {
            crateText = GetComponentInChildren<Text>();
        }
        UpdateCrateText();
    }

    void Update()
    {
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);

        if (transform.position.y < -10f)
        {
            Destroy(gameObject);
        }
    }

    public void UpdateCrateText()
    {
        if (crateText != null)
        {
            crateText.text = crateValue.ToString();
            Debug.Log("Crate text updated to: " + crateText.text);
        }
    }


    public void HandleBulletCollision(int bulletValue)
    {

        Debug.Log("Bullet Hit Crate with value: " + bulletValue);
        Debug.Log("Current Crate Value Before Hit: " + crateValue);

        crateValue -= bulletValue;

        Debug.Log("Crate value after hit: " + crateValue);
        UpdateCrateText();

        if (crateValue <= 0)
        {
            Debug.Log("Crate destroyed");
            Destroy(gameObject);
        }
    }


}
