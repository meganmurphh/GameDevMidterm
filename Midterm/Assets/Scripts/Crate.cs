using UnityEngine;
using UnityEngine.UI;

public class Crate : MonoBehaviour
{
    public int crateValue; 
    public Text crateText;
    public float fallSpeed = 2f;

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

        if (transform.position.y < -15f)
        {
            Destroy(gameObject);
        }
    }

    public void UpdateCrateText()
    {
        if (crateText != null)
        {
            crateText.text = crateValue.ToString();
        }
    }

    public void HandleBulletCollision(int bulletValue)
    {
        Debug.Log("Bullet Hit Crate");
        crateValue -= bulletValue;

        UpdateCrateText();

        if (crateValue <= 0)
        {
            Destroy(gameObject);
        }
    }
}
