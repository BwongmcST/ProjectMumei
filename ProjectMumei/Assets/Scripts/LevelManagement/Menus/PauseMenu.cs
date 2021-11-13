using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LevelManagement {
    public class PauseMenu : Menu<PauseMenu>
    {
        [SerializeField]
        private int _mainMenuIndex = 0;

        public void OnResumePressed()
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            MenuManager.instance.isPaused = false;
            base.OnBackPressed();
        }

        public void OnRestartPressed()
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            MenuManager.instance.isPaused = false;
            base.OnBackPressed();
        }

        public void OnMainMenuPressed()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(_mainMenuIndex);
            if(MenuManager.instance != null && MainMenu.instance != null)
            {
                MenuManager.instance.OpenMenu(MainMenu.instance);
            }
            MenuManager.instance.isPaused = false;
            Cursor.lockState = CursorLockMode.None;
        }
        public void OnQuitPressed()
        {
            Application.Quit();
        }



    }
}
