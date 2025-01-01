using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverCondition : MonoBehaviour
{
    [SerializeField] private Transform target; 
    [SerializeField] private float checkRadius = 100f; 
    [SerializeField] private int maxGoblins = 5; 
    [SerializeField] private GameObject gameOverPanel; 

    private void Update()
    {
        if (target == null)
        {
            return;
        }

       
        //все объекты вокруг цели
        Collider[] colliders = Physics.OverlapSphere(target.position, checkRadius);
        int goblinCount = 0;

        foreach (var collider in colliders)
        {
            if (collider.CompareTag("Goblin")) // проверяем, есть ли гоблины
            {
                Debug.Log($"Goblin detected: {collider.gameObject.name}");
                goblinCount++;
            }
        }

        // если гоблинов больше допустимого количества, завершаем игру
        if (goblinCount > maxGoblins)
        {           
            EndGame();
        }
    }

    private void EndGame()
    {
        Debug.Log("Game Over");
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true); // показываем панель Game Over 2
        }
        Time.timeScale = 0; // останавливаем игру
    }
}
