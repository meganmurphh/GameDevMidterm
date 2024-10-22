using UnityEngine;

public class KeyPressed : MonoBehaviour
{
    public GameObject sKey; // Reference to the S key GameObject
    public GameObject dKey; // Reference to the D key GameObject
    public GameObject fKey; // Reference to the F key GameObject

    public GameObject spherePrefab; // Reference to the sphere prefab
    public Transform cannonArm; // Reference to the cannon arm's position

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
            ShootSphere();
        }
        else
        {
            ChangeColor(sKey, originalColorS);
        }

        // Check if the D key is pressed
        if (Input.GetKeyDown(KeyCode.D)) // Change to GetKeyDown
        {
            ChangeColor(dKey, lightGreyColor);
            ShootSphere();
        }
        else
        {
            ChangeColor(dKey, originalColorD);
        }

        // Check if the F key is pressed
        if (Input.GetKeyDown(KeyCode.F)) // Change to GetKeyDown
        {
            ChangeColor(fKey, lightGreyColor);
            ShootSphere();
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
    private void ShootSphere()
    {
        // Calculate the spawn position based on the cannon arm's position and its rotation
        Vector3 spawnPosition = cannonArm.position + cannonArm.forward * 1.3f + cannonArm.up * 1.3f;

        // Instantiate the sphere at the calculated position
        GameObject sphere = Instantiate(spherePrefab, spawnPosition, cannonArm.rotation);

        // Add force to the sphere's Rigidbody to shoot it upwards
        Rigidbody rb = sphere.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = false; // Make sure it's not kinematic
            rb.AddForce(cannonArm.up * shootForce); // Shoot it straight up
        }
    }
}
