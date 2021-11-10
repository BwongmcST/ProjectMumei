using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
  
    public void ReloadLevel()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        LoadLevel(currentScene.buildIndex);
    }

    private void LoadLevel(int levelIndex)
    {
        if(levelIndex >= 0 && levelIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(levelIndex);
        }
        else
        {
            Debug.LogWarning("GameManager LoadLevel Error: invalid scene specified");
        }
    }
    public void LoadNexLevel()
    {
        int nextSceneIndex = (SceneManager.GetActiveScene().buildIndex + 1) % SceneManager.sceneCountInBuildSettings;
        LoadLevel(nextSceneIndex);
    }


}
