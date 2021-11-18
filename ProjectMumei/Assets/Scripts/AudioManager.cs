using UnityEngine;
using UnityEngine.Audio;
using System;

namespace AudioManagement {
    public class AudioManager : MonoBehaviour
    {
        private static AudioManager _instance;
        public static AudioManager instance
        {
            get { return _instance; }
        }

        [SerializeField] private BGM[] bgmA;
        [SerializeField] private SFX[] sfxA;

        private float BGMVolume;
        private float SFXVolume;
        private float MasterVolume;


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
                InitializedAudio();
            }
        }

        private void InitializedAudio()
        {
            MasterVolume = PlayerPrefs.GetFloat("MasterVolume");
            SFXVolume = PlayerPrefs.GetFloat("SFXVolume");
            BGMVolume = PlayerPrefs.GetFloat("MusicVolumn");

            foreach (BGM b in bgmA)
            {
                b.source = gameObject.AddComponent<AudioSource>();
                b.source.clip = b.clip;
                b.source.volume = b.volume * MasterVolume * BGMVolume;
                b.source.loop = b.isLoop;
            }

            foreach (SFX s in sfxA)
            {
                s.source = gameObject.AddComponent<AudioSource>();
                s.source.clip = s.clip;
                s.source.volume = s.volume * MasterVolume * SFXVolume;
            }
        }

        public void PlayBGM(string name)
        {
            BGM b = Array.Find(bgmA, bgm => bgm.name == name);
            b.source.Play();
        }

        public void PlaySFX(string name)
        {
            SFX s = Array.Find(sfxA, sfx => sfx.name == name);
            s.source.PlayOneShot(s.clip);
        }

        public void StopBGM(string name)
        {
            BGM b = Array.Find(bgmA, bgm => bgm.name == name);
            b.source.Stop();
        }

        public void AudioUpdate()
        {
            MasterVolume = PlayerPrefs.GetFloat("MasterVolume");
            SFXVolume = PlayerPrefs.GetFloat("SFXVolume");
            BGMVolume = PlayerPrefs.GetFloat("MusicVolumn");

            foreach (BGM b in bgmA)
            {
                b.source.volume = b.volume * MasterVolume * BGMVolume;
            }

            foreach (SFX s in sfxA)
            {
                s.source.volume = s.volume * MasterVolume * SFXVolume;
            }
        }
    }
}
