using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverImage;

    public void GameOver()
    {
        if (gameOverImage != null)
        {
            gameOverImage.SetActive(true); // Image Game Over
        }
        Time.timeScale = 0; // останавливаем игру
    }
}
