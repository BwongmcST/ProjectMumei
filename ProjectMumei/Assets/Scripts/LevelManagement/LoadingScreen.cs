using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LevelManagement {
public class LoadingScreen : Menu
{
        /* Junk (Keep the script in loadingScreen prefab)
        public Slider slider;
        public void OnScreenLoading()
        {
            Menu LoadingScreen = transform.parent.Find("LoadingScreen(Clone)").GetComponent<Menu>();
            MenuManager.instance.OpenMenu(LoadingScreen);
            slider.value = GameManager.instance.loadProgress;
        }
        */
    }

}
