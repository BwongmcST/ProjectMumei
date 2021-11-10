using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LevelManagement {
    public class MainMenu : Menu
    {
        public Slider slider;
        public void OnScreenLoading()  // loading Screen & Loading Bar (Couldn't test the function because it loads too fast, but no error so far)
        {
            Menu LoadingScreen = transform.parent.Find("LoadingScreen(Clone)").GetComponent<Menu>();
            slider = transform.parent.Find("LoadingScreen(Clone)").GetComponentInChildren<Slider>();
            MenuManager.instance.OpenMenu(LoadingScreen);
            slider.value = GameManager.instance.loadProgress;
        }

        public void OnPlayPressed()
        {
            OnScreenLoading();
            if (GameManager.instance != null)
            {
                GameManager.instance.LoadNexLevel();
            }

        }

        public void OnSettingsPressed()
        {
            Menu settingsMenu = transform.parent.Find("SettingsMenu(Clone)").GetComponent<Menu>();
            if (MenuManager.instance != null && settingsMenu != null)
            {
                MenuManager.instance.OpenMenu(settingsMenu);
            }
        }
        public void OnCreditsPressed()
        {
            Menu creditsMenu = transform.parent.Find("CreditsMenu(Clone)").GetComponent<Menu>();
            if (MenuManager.instance != null && creditsMenu != null)
            {
                MenuManager.instance.OpenMenu(creditsMenu);
            }
        }
        public override void OnBackPressed()
        {
            Application.Quit();
        }
    }
}