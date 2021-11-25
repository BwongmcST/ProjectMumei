using UnityEngine;
using UnityEngine.Audio;

namespace AudioManagement
{
    [System.Serializable]
    public class SFX
    {
        public string name;
        public AudioClip clip;
        [Range(0f, 1f)] public float volume;


        [HideInInspector]
        public AudioSource source;
    }
}
