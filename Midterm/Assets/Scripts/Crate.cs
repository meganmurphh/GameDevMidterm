using UnityEngine;
using UnityEngine.UI;

public class Crate : MonoBehaviour
{
    public int crateValue;
    public float fallSpeed = 1f;
    public float minYPos = -5f;

    private Text crateText;
    private Player player;
    private bool destroyedByPlayer = false;

    void Start()
    {
        crateText = GetComponentInChildren<Text>();
        UpdateCrateText();
        player = FindObjectOfType<Player>();
    }

    public void UpdateCrateText()
    {
        if (crateText != null)
        {
            crateText.text = crateValue.ToString();
        }
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Bullet"))
        {

            Text bulletText = collision.gameObject.GetComponentInChildren<Text>();
            if (bulletText != null && int.TryParse(bulletText.text, out int bulletValue))
            {
                crateValue -= bulletValue;

                crateText.text = crateValue.ToString();

                if (crateValue == 0)
                {
                    destroyedByPlayer = true;

                    if (player != null)
                    {
                        KeyPressed keyPressed = FindObjectOfType<KeyPressed>();
                        if (keyPressed != null)
                        {
                            player.points += keyPressed.lastBulletType;
                        }
                    }

                    Destroy(gameObject);

                }
                else if (crateValue < 0)
                {
                    if (player != null)
                    {
                        KeyPressed keyPressed = FindObjectOfType<KeyPressed>();
                        if (keyPressed != null)
                        {
                            player.points -= keyPressed.lastBulletType;
                        }
                    }

                    Destroy(gameObject);

                }

            }
            else
            {
                Debug.LogError("Bullet value could not be parsed from bullet text.");
            }

            Destroy(collision.gameObject);
        }
    }

    void FixedUpdate()
    {
        Rigidbody crateRb = GetComponent<Rigidbody>();
        if (crateRb != null && !crateRb.isKinematic)
        {
            crateRb.velocity = new Vector3(crateRb.velocity.x, -fallSpeed, crateRb.velocity.z);
        }

        if (transform.position.y < minYPos)
        {
            DestroyOutOfBoundsCrate();
        }
    }

    private void DestroyOutOfBoundsCrate()
    {
        destroyedByPlayer = false;
        Destroy(gameObject);
    }

    void OnDestroy()
    {
        if (destroyedByPlayer)
        {
            LevelManager levelManager = FindObjectOfType<LevelManager>();
            if (levelManager != null)
            {
                levelManager.CrateDestroyed();
            }
        }
    }

}
