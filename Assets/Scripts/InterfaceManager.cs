using UnityEngine;

public class InterfaceManager : MonoBehaviour
{
    [SerializeField] private PauseMenu pauseMenu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M)) // откр/закр меню паузы
        {
            OpenClosePauseMenu();
        }
    }

    public void OpenClosePauseMenu()
    {
        if (!pauseMenu.gameObject.activeSelf)
        {
            pauseMenu.Show();
            Time.timeScale = 0; // остановить игру
        }
        else
        {
            pauseMenu.Hide();
            Time.timeScale = 1; // возобновить игру
        }
    }
}

