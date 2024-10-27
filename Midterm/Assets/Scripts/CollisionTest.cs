using UnityEngine;
using UnityEngine.UI;

public class CollisionTest : MonoBehaviour
{
    private Text crateText;
    public int crateValue;

    public float fallSpeed = 1.5f;

    private AudioSource audioSource;
    public AudioClip destructionSound;

    private Player player;

    void Start()
    {
        crateText = GetComponentInChildren<Text>();
        UpdateCrateText();
        player = FindObjectOfType<Player>();
        audioSource = GetComponent<AudioSource>();
        if (audioSource != null && destructionSound != null)
        {
            audioSource.clip = destructionSound;
        }
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
                    Debug.Log("Crate destroyed");
                    PlayDestructionSound();

                    if (player != null)
                    {
                        KeyPressed keyPressed = FindObjectOfType<KeyPressed>();
                        if (keyPressed != null)
                        {
                            player.points += keyPressed.lastBulletType;
                            Debug.Log($"Points awarded: {keyPressed.lastBulletType}. Total points: {player.points}");
                        }
                    }

                    Destroy(gameObject);

                } else if (crateValue < 0)
                {
                    if (player != null)
                    {
                        KeyPressed keyPressed = FindObjectOfType<KeyPressed>();
                        if (keyPressed != null)
                        {
                            player.points -= keyPressed.lastBulletType;
                            Debug.Log($"Points deducted: {keyPressed.lastBulletType}. Total points: {player.points}");
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

    void PlayDestructionSound()
    {
        if (audioSource != null)
        {
            audioSource.Play();
            Debug.Log("Playing sound: " + audioSource.clip.name); 
        }
        else
        {
            Debug.LogError("AudioSource is null!");
        }
    }

    void FixedUpdate()
    {
        Rigidbody crateRb = GetComponent<Rigidbody>();
        if (crateRb != null && !crateRb.isKinematic)
        {
            crateRb.velocity = new Vector3(crateRb.velocity.x, -fallSpeed, crateRb.velocity.z);
        }
    }

    void OnDestroy()
    {
        LevelManager levelManager = FindObjectOfType<LevelManager>();
        if (levelManager != null)
        {
            levelManager.CrateDestroyed();
        }
    }

}
