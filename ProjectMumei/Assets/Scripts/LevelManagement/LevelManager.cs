using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LevelManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;

    private void Awake()
    {
        _canvas.gameObject.SetActive(true);
    }
    void Start()
    {    
        if(MainMenu.instance.LoadingScreen != null)
        {
            Debug.Log("ACTIVE");
            MenuManager.instance.CloseAllMenu();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        PauseLevel();
    }

    private void PauseLevel()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && MenuManager.instance.isPaused != true)
        {
            MenuManager.instance.OpenMenu(PauseMenu.instance);  
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            MenuManager.instance.isPaused = true;
        }
    }
}
