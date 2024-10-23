using UnityEngine;
using UnityEngine.UI;

public class Crate : MonoBehaviour
{
    public int crateValue;
    public Text crateText;
    public float fallSpeed = 2f;

    void Start()
    {
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
        }
    }
}
