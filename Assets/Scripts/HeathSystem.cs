using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3;
    private int currentHealth;
    private GameUI gameUI;

    private AudioSource AudioSource;

    [SerializeField] private AudioClip damageSound;
    [SerializeField] private AudioClip gameOverSound;

    void Start()
    {
        currentHealth = maxHealth;
        gameUI = FindAnyObjectByType<GameUI>();

        if (gameUI != null)
        {
            gameUI.UpdateHearts(currentHealth);
        }

        AudioSource = GetComponent<AudioSource>();

    }

    public void TakeDamage()
    {
        if (currentHealth <= 0) return;

        currentHealth--;

        if (gameUI != null)
        {
            gameUI.UpdateHearts(currentHealth);
        }
        if (damageSound != null && AudioSource != null) {
            AudioSource.PlayOneShot(damageSound);

        }

        Debug.Log("Health: " + currentHealth);

        if (currentHealth == 0)
        {
            AudioSource.PlayOneShot(gameOverSound);
            Debug.Log("Player has no health left!");
        }

    }
}
