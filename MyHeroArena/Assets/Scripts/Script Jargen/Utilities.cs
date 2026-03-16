using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 1 
using UnityEngine.SceneManagement;

// 2 
public static class Utilities
{
    // 3 
    public static int PlayerDeaths = 0;

    public static string UpdateDeathCount(ref int countReference)
    {
        // 2 
        countReference += 1;
        return "Next time you'll be at number " + countReference;
    }

    // 4 
    public static void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1.0f;
    }
    public static bool RestartLevel(int sceneIndex)
    {
        Debug.Log("Player deaths: " + PlayerDeaths);
        string message = UpdateDeathCount(ref PlayerDeaths);
        Debug.Log("Player deaths: " + PlayerDeaths);
        Debug.Log(message);
        
        SceneManager.LoadScene(sceneIndex);
        Time.timeScale = 1.0f;
         
        return true;
    }
}
