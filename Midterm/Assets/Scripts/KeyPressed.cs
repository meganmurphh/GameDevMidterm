using UnityEngine;
using UnityEngine.UI;

public class KeyPressed : MonoBehaviour
{
    public GameObject sKey;
    public GameObject dKey;
    public GameObject fKey;

    public GameObject bullet;

    public Transform cannonArm;

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
            Debug.Log("Bullet One shot");
        }
        else
        {
            ChangeColor(sKey, originalColorS);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            ChangeColor(dKey, lightGreyColor);
            ShootSphere(2);
            Debug.Log("Bullet Two shot");
        }
        else
        {
            ChangeColor(dKey, originalColorD);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            ChangeColor(fKey, lightGreyColor);
            ShootSphere(3);
            Debug.Log("Bullet Three shot");
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

    private void ShootSphere(int bulletNumber)
    {
        // Instantiate the bullet object based on the key pressed
        GameObject bulletObject = Instantiate(bullet, cannonArm.position + cannonArm.up * 1.5f, cannonArm.rotation);

        Rigidbody rb = bulletObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = false;
            rb.AddForce(cannonArm.up * shootForce);
        }

        Text bulletText = bulletObject.GetComponentInChildren<Text>();
        if (bulletText != null)
        {
            bulletText.text = bulletNumber.ToString(); // Set the text based on the key number
        }
    }
}
