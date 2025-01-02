using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [SerializeField] private Text timerText; 
    [SerializeField] private float gameDuration = 60f; // в секундах
    [SerializeField] private GameObject winPanel; 
    [SerializeField] private GameObject losePanel; 

    private float timeRemaining; 
    private bool isGameActive = true; 

    private void Start()
    {
        timeRemaining = gameDuration;
        winPanel.SetActive(false); 
        losePanel.SetActive(false); 
    }

    private void Update()
    {
        if (isGameActive)
        {
            // уменьшаем таймер
            timeRemaining -= Time.deltaTime;

            // обновляем отображение таймера
            timerText.text = $"Time: {Mathf.Max(0, timeRemaining):0.0}";

            // проверяем условия победы или поражения
            if (timeRemaining <= 0)
            {
                WinGame();
            }
        }
    }

    public void LoseGame()
    {
        if (isGameActive)
        {
            isGameActive = false;
            losePanel.SetActive(true); 
            Time.timeScale = 0; // останавливаем игру
        }
    }

    private void WinGame()
    {
        if (isGameActive)
        {
            isGameActive = false;
            winPanel.SetActive(true); 
            Time.timeScale = 0; // останавливаем игру
        }
    }
}
