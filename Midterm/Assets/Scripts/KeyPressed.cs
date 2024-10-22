using UnityEngine;
using UnityEngine.UI;

public class KeyPressed : MonoBehaviour
{
    public GameObject sKey; // Reference to the S key GameObject
    public GameObject dKey; // Reference to the D key GameObject
    public GameObject fKey; // Reference to the F key GameObject

    public GameObject bullet; // Reference to the sphere prefab
    public Transform cannonArm; // Reference to the cannon arm's position

    public GameObject bulletValueText;
    public Canvas bulletTextCanvas;

    public float shootForce = 500f; // Force with which the sphere will be shot

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
        if (Input.GetKeyDown(KeyCode.S)) // Change to GetKeyDown
        {
            ChangeColor(sKey, lightGreyColor);
            ShootSphere(1);
            Debug.Log("Number 1 shot");
        }
        else
        {
            ChangeColor(sKey, originalColorS);
        }

        // Check if the D key is pressed
        if (Input.GetKeyDown(KeyCode.D)) // Change to GetKeyDown
        {
            ChangeColor(dKey, lightGreyColor);
            ShootSphere(2);
            Debug.Log("Number 2 shot");

        }
        else
        {
            ChangeColor(dKey, originalColorD);
        }

        // Check if the F key is pressed
        if (Input.GetKeyDown(KeyCode.F)) // Change to GetKeyDown
        {
            ChangeColor(fKey, lightGreyColor);
            ShootSphere(3);
            Debug.Log("Number 3 shot");

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

    // Function to shoot a sphere from the cannon arm
    private void ShootSphere(int keyNumber)
    {
        // Calculate the spawn position based on the cannon arm's position and its rotation
        Vector3 spawnPosition = cannonArm.position + cannonArm.forward * 1.3f + cannonArm.up * 1.3f;

        // Instantiate the sphere at the calculated position
        GameObject bulletObject = Instantiate(bullet, spawnPosition, cannonArm.rotation);

        // Add force to the sphere's Rigidbody to shoot it upwards
        Rigidbody rb = bulletObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = false; // Make sure it's not kinematic
            rb.AddForce(cannonArm.up * shootForce); // Shoot it straight up
        }

        DisplayValueText(keyNumber, bulletObject.transform);

    }

    // Function to display legacy text
    private void DisplayValueText(int keyNumber, Transform sphereTransform)
    {
        // Instantiate the legacy text prefab at the position above the bullet
        GameObject textObject = Instantiate(bulletValueText, sphereTransform.position + Vector3.up * 1.5f, Quaternion.identity);

        // Get the Text component from the instantiated object
        Text numberUIText = textObject.GetComponent<Text>();
        numberUIText.text = keyNumber.ToString(); // Set the text based on the key number

        // Set the text as a child of the World Space Canvas
        if (bulletTextCanvas != null)
        {
            textObject.transform.SetParent(bulletTextCanvas.transform, false); // Parent to the bullet text canvas
        }
        else
        {
            Debug.LogError("Bullet Text Canvas is not assigned in the Inspector.");
        }

        // Position adjustment to make sure text appears correctly above the sphere
        textObject.transform.position = sphereTransform.position + Vector3.up * 1.5f; // Adjust height as necessary
    }
}
