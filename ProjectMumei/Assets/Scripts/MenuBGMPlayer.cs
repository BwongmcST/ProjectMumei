using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AudioManagement;

public class MenuBGMPlayer : MonoBehaviour
{
    private void Start()
    {
        PlayMenuBGM();
    }

    private void PlayMenuBGM()
    {
        AudioManager.instance.PlayBGM("MenuBGM");
    }


}
