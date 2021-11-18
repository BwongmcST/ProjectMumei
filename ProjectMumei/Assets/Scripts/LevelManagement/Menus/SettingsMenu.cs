using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AudioManagement;


namespace LevelManagement
{
    public class SettingsMenu : Menu<SettingsMenu>
    {
        [SerializeField] private Slider _masterVolumeSlider;
        [SerializeField] private Slider _sfxVolumeSlider;
        [SerializeField] private Slider _musicVolumeSlider;

        protected override void Awake()
        {
            base.Awake();
            LoadPreferences();
        }
        public override void OnBackPressed()
        {
            base.OnBackPressed();
            PlayerPrefs.Save();
        }

        public void OnMasterSoundChange(float volume)
        {
            PlayerPrefs.SetFloat("MasterVolume", volume);
            AudioManager.instance.AudioUpdate();

        }
        public void OnSFXVolumnPressedChange(float volume)
        {
            PlayerPrefs.SetFloat("SFXVolume", volume);
            AudioManager.instance.AudioUpdate();
        }

        public void OnMusicVolumnPressedChange(float volume)
        {
            PlayerPrefs.SetFloat("MusicVolumn", volume);
            AudioManager.instance.AudioUpdate();
        }

        public void LoadPreferences()
        {
            _masterVolumeSlider.value = PlayerPrefs.GetFloat("MasterVolume");
            _sfxVolumeSlider.value = PlayerPrefs.GetFloat("SFXVolume");
            _musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolumn");
        }

    }
}