using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AudioManagement;

namespace LevelManagement {
    public class MainMenu : Menu<MainMenu>
    {
        public Slider slider;
        public Menu LoadingScreen;
        public void OnScreenLoading()  // loading Screen & Loading Bar (Couldn't test the function because it loads too fast, but no error so far)
        {
            LoadingScreen = transform.parent.Find("LoadingScreen(Clone)").GetComponent<Menu>();
            slider = transform.parent.Find("LoadingScreen(Clone)").GetComponentInChildren<Slider>();
            MenuManager.instance.OpenMenu(LoadingScreen);
            slider.value = GameManager.instance.loadProgress;
        }

        public void OnPlayPressed()
        {
            if (GameManager.instance != null)
            {
                OnScreenLoading();
                AudioManager.instance.StopBGM("MenuBGM");
                GameManager.instance.LoadNexLevel();
            }

        }

        public void OnSettingsPressed()
        {
            if (MenuManager.instance != null && SettingsMenu.instance != null)
            {
                MenuManager.instance.OpenMenu(SettingsMenu.instance);
            }
        }
        public void OnCreditsPressed()
        {
            if (MenuManager.instance != null && CreditsMenu.instance != null)
            {
                MenuManager.instance.OpenMenu(CreditsMenu.instance);
            }
        }
        public override void OnBackPressed()
        {
            Application.Quit();
        }

        private void StopBGM()
        {
            AudioManager.instance.StopBGM("MenuBGM");
        }
    }


}