using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public static bool GamePaused = false;
    public GameObject pauseMenuUI; 
    public GameObject MainUI;
    public GameObject audioMenuUI;



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!GamePaused)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    } 
    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false); 
        MainUI.SetActive(true);
        Time.timeScale = 1f; 
        GamePaused = false;
    }

    public void PauseGame()
    {
        pauseMenuUI.SetActive(true); 
        MainUI.SetActive(false);
        Time.timeScale = 0f;
        GamePaused = true;
    } 
    public void OpenAudio()
    {
        audioMenuUI.SetActive(true);
        pauseMenuUI.SetActive(false);
    } 
    public void CloseAudio()
    {
        audioMenuUI.SetActive(false); 
        pauseMenuUI.SetActive(true);
    }
    public void ToMainMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
