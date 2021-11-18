using UnityEngine;
using UnityEngine.Audio;

namespace AudioManagement
{
    [System.Serializable]
    public class BGM
    {
        public string name;
        public AudioClip clip;
        [Range(0f, 1f)] public float volume;
        public bool isLoop;

        [HideInInspector]
        public AudioSource source;
    }
}