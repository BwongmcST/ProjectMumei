using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using LevelManagement;

public class GameManager : MonoBehaviour
{
    public float loadProgress;
    private static GameManager _instance;
    [SerializeField] private int _mainMenuIndex = 0;
    public static GameManager instance
    {
        get { return _instance; }
    }

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ReloadLevel()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        LoadLevel(currentScene.buildIndex);
    }

    private void LoadLevel(int levelIndex)
    {
        if(levelIndex >= 0 && levelIndex < SceneManager.sceneCountInBuildSettings)
        {
            if (levelIndex == _mainMenuIndex && MenuManager.instance != null && MainMenu.instance != null)
            {
                Cursor.lockState = CursorLockMode.None;
                MenuManager.instance.OpenMenu(MainMenu.instance);
            }

            StartCoroutine(LoadAsynchoronously(levelIndex));
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

    IEnumerator LoadAsynchoronously(int LevelIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(LevelIndex);
        while (!operation.isDone)
        {
            float loadProgress = Mathf.Clamp01(operation.progress / 0.9f);  //Clamps value between 0 and 1 and returns value.
            //Debug.Log(loadProgress);

            yield return null;
        }
    }

}
