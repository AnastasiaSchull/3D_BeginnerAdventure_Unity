using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float health = 100f;
    private GameManager gameManager;

    private void Start()
    {
        // найдем GameManager на сцене
        gameManager = FindObjectOfType<GameManager>();
    }

    public void TakeDamage(float damage)
    {
        health -= 5*damage;
        Debug.Log($"player took {damage} damage! health: {health}");
        if (health <= 0)
        {
            Debug.Log("Player is dead!");
            gameManager.GameOver();
        }
    }
}
