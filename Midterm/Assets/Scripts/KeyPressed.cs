using UnityEngine;

public class KeyPressed : MonoBehaviour
{
    public GameObject sKey; // Reference to the S key GameObject
    public GameObject dKey; // Reference to the D key GameObject
    public GameObject fKey; // Reference to the F key GameObject

    // Define the light grey color
    private Color lightGreyColor = new Color(0.75f, 0.75f, 0.75f);

    // Store original colors
    private Color originalColorS;
    private Color originalColorD;
    private Color originalColorF;

    void Start()
    {
        // Get the original colors of the key GameObjects
        originalColorS = sKey.GetComponent<Renderer>().material.color;
        originalColorD = dKey.GetComponent<Renderer>().material.color;
        originalColorF = fKey.GetComponent<Renderer>().material.color;
    }

    void Update()
    {
        // Check if the S key is pressed
        if (Input.GetKey(KeyCode.S))
        {
            ChangeColor(sKey, lightGreyColor);
        }
        else
        {
            ChangeColor(sKey, originalColorS);
        }

        // Check if the D key is pressed
        if (Input.GetKey(KeyCode.D))
        {
            ChangeColor(dKey, lightGreyColor);
        }
        else
        {
            ChangeColor(dKey, originalColorD);
        }

        // Check if the F key is pressed
        if (Input.GetKey(KeyCode.F))
        {
            ChangeColor(fKey, lightGreyColor);
        }
        else
        {
            ChangeColor(fKey, originalColorF);
        }
    }

    // Function to change the color of a GameObject
    private void ChangeColor(GameObject key, Color color)
    {
        key.GetComponent<Renderer>().material.color = color;
    }
}
