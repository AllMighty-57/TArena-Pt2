using Unity.VisualScripting;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public static bool GamePaused = false;
    public GameObject pauseMenuUI; 
    public GameObject MainUI;



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
}
