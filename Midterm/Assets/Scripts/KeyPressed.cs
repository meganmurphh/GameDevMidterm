using UnityEngine;
using UnityEngine.UI;

public class KeyPressed : MonoBehaviour
{
    public GameObject sKey;
    public GameObject dKey; 
    public GameObject fKey; 

    public GameObject bullet; 
    public Transform cannonArm; 

    public GameObject bulletValueText;
    public Canvas bulletTextCanvas;

    public float shootForce = 500f;

    private Color lightGreyColor = new Color(0.75f, 0.75f, 0.75f);

    private Color originalColorS;
    private Color originalColorD;
    private Color originalColorF;

    void Start()
    {
        originalColorS = sKey.GetComponent<Renderer>().material.color;
        originalColorD = dKey.GetComponent<Renderer>().material.color;
        originalColorF = fKey.GetComponent<Renderer>().material.color;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            ChangeColor(sKey, lightGreyColor);
            ShootSphere(1);
            Debug.Log("Number 1 shot");
        }
        else
        {
            ChangeColor(sKey, originalColorS);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            ChangeColor(dKey, lightGreyColor);
            ShootSphere(2);
            Debug.Log("Number 2 shot");

        }
        else
        {
            ChangeColor(dKey, originalColorD);
        }

        if (Input.GetKeyDown(KeyCode.F))
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

    private void ChangeColor(GameObject key, Color color)
    {
        key.GetComponent<Renderer>().material.color = color;
    }

    private void ShootSphere(int keyNumber)
    {
        GameObject bulletObject = Instantiate(bullet, cannonArm.position + cannonArm.up * 1.5f, cannonArm.rotation);

        Rigidbody rb = bulletObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = false;
            rb.AddForce(cannonArm.up * shootForce);
        }

        DisplayValueText(keyNumber, bulletObject);

    }
    private void DisplayValueText(int keyNumber, GameObject parentSphere)
    {
        // Instantiate the text prefab at the position above the bullet
        GameObject textObject = Instantiate(bulletValueText, parentSphere.transform.position + Vector3.up * 1.5f, Quaternion.identity);

        // Get the Text component from the instantiated object
        Text numberUIText = textObject.GetComponent<Text>();
        numberUIText.text = keyNumber.ToString(); // Set the text based on the key number

        // Attach the FollowBullet script to the text object and set the bulletTransform
        FollowBullet followBulletScript = textObject.GetComponent<FollowBullet>();
        followBulletScript.bulletTransform = parentSphere.transform;

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
        textObject.transform.position = parentSphere.transform.position + Vector3.up * 1.5f; // Adjust height as necessary
    }



}
