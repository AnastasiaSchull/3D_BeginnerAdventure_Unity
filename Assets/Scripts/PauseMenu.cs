using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused;

    [SerializeField] private Button resumeBtn;
    [SerializeField] private Button settingsBtn;
    [SerializeField] private Button restartBtn;
    [SerializeField] private Button quitBtn;

    private void Awake()
    {
        Debug.Log("PauseMenu initialized");
        resumeBtn.onClick.AddListener(() => Hide());
        restartBtn.onClick.AddListener(() => Restart());
        quitBtn.onClick.AddListener(() => Quit());

    }
    void Update()
    {

    }

    public void Show()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;//пауза
        isPaused = true;
    }

    public void Hide()
    {
        gameObject.SetActive(false);//видимо или невидимо меню
        Time.timeScale = 1;
        isPaused = false;
    }

    public void Restart()
    {
        Debug.Log("Restart button clicked!");
        Time.timeScale = 1;
        isPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        Debug.Log("Quitting the game..."); 
        Application.Quit(); 
    }

}

