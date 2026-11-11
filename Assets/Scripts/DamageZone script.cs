using UnityEngine;

public class DamageZone : MonoBehaviour
{
    [SerializeField] private float healthCooldown = 3f;
    private float scoreTimer = 0f;
    private float healthTimer = 0f;
    private GameUI gameUI;

    void Awake()
    {
        gameUI = FindAnyObjectByType<GameUI>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        HealthSystem health = other.GetComponent<HealthSystem>();

        if (health != null)
        {
            health.TakeDamage();
        }

        healthTimer = 0f;
    }

    void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        scoreTimer += Time.fixedDeltaTime;

        if (scoreTimer >= 1f)
        {
            if (gameUI != null)
            {
                gameUI.RemoveScore(1);
            }

            scoreTimer = 0f;
        }

        healthTimer += Time.fixedDeltaTime;

        if (healthTimer >= healthCooldown)
        {
            HealthSystem health = other.GetComponent<HealthSystem>();

            if (health != null)
            {
                health.TakeDamage();
            }

            healthTimer = 0f;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            scoreTimer = 0f;
            healthTimer = 0f;
        }
    }
}
