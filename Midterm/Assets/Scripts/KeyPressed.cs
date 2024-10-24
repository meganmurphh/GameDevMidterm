using UnityEngine;
using UnityEngine.UI;

public class KeyPressed : MonoBehaviour
{
    public GameObject sKey;
    public GameObject dKey;
    public GameObject fKey;

    public GameObject bullet;

    public Transform cannonArm;

    public float shootForce = 450f;

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
            ShootBullet(1);
        }
        else
        {
            ChangeColor(sKey, originalColorS);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            ChangeColor(dKey, lightGreyColor);
            ShootBullet(2);
        }
        else
        {
            ChangeColor(dKey, originalColorD);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            ChangeColor(fKey, lightGreyColor);
            ShootBullet(3);
        }
        else
        {
            ChangeColor(fKey, originalColorF);
        }
    }

    private void ShootBullet(int bulletNumber)
    {
        GameObject bulletObject = Instantiate(bullet, cannonArm.position + cannonArm.up * 2f, cannonArm.rotation);

        // Debug log for bullet position and rotation
        Debug.Log("Bullet instantiated at: " + bulletObject.transform.position);
        Debug.Log("Bullet rotation: " + bulletObject.transform.rotation);

        Rigidbody rb = bulletObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = false;
            rb.AddForce(cannonArm.up * shootForce);
            Debug.Log("Bullet force applied: " + cannonArm.up * shootForce);
        }
        else
        {
            Debug.LogError("Rigidbody not found on the instantiated bullet.");
        }

        Text bulletText = bulletObject.GetComponentInChildren<Text>();
        if (bulletText != null)
        {
            bulletText.text = bulletNumber.ToString();
            Debug.Log("Bullet number set to: " + bulletText.text);
        }
        else
        {
            Debug.LogError("Bullet text component not found in instantiated bullet.");
        }
    }



    private void ChangeColor(GameObject key, Color color)
    {
        key.GetComponent<Renderer>().material.color = color;
    }
}
