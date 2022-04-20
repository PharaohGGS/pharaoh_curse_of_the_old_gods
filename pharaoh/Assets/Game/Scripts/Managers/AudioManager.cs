using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

namespace Pharaoh.Managers
{
    public class AudioManager : MonoBehaviour
    {

        public static AudioManager Instance { get; private set; }

        [Space(10)]
        [Header("Doors and crates and plates sound")]
        [SerializeField]
        private AudioClip[] doorOpensClips;
        [SerializeField]
        private AudioClip[] doorClosesClips;
        [SerializeField]
        private AudioClip[] plateOnClips;
        [SerializeField]
        private AudioClip[] plateOffClips;
        [SerializeField]
        private AudioClip[] cratePullClips;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }

            foreach (Sound s in sounds)
            {
                s.audioSource = gameObject.AddComponent<AudioSource>();
                s.audioSource.outputAudioMixerGroup = s.audioMixerGroup;
                s.audioSource.clip = s.clip;
                s.audioSource.volume = s.volume;
                s.audioSource.pitch = s.pitch;
                s.audioSource.loop = s.loop;
            }
        }

        [System.Serializable]
        public class Sound
        {
            public string name;
            public AudioClip clip;
            [Range(0f, 1f)] public float volume = 1f;
            [Range(.1f, 3f)] public float pitch = 1f;
            public AudioMixerGroup audioMixerGroup;
            public bool loop = false;
            public bool fadeIn = false;
            public bool fadeOut = false;
            public float fadeInDuration = 1f;
            public float fadeOutDuration = 1f;
            public bool randomized = false;
            [HideInInspector] public AudioSource audioSource;
        }

        public Sound[] sounds;

        public void Play(string name)
        {
            Sound s = Array.Find(sounds, sound => sound.name == name);

            if (s == null)
            {
                Debug.LogWarning("Sound " + name + " not found !");
                return;
            }

            if(s.randomized)
            {
                switch (name)
                {
                    case "DoorOpens":
                        s.audioSource.clip = GetRandomClip(doorOpensClips);
                        break;
                    case "DoorCloses":
                        s.audioSource.clip = GetRandomClip(doorClosesClips);
                        break;
                    case "PlateOn":
                        s.audioSource.clip = GetRandomClip(plateOnClips);
                        break;
                    case "PlateOff":
                        s.audioSource.clip = GetRandomClip(plateOffClips);
                        break;
                    case "cratePull":
                        s.audioSource.clip = GetRandomClip(cratePullClips);
                        break;
                    default :
                        Debug.LogWarning("Random sound " + name + " not found !");
                        break;
                }
            }

            s.audioSource?.Play();
            if (s.fadeIn)
            {
                StartCoroutine(StartFadeIn(s.audioSource, s.fadeInDuration, s.volume));
            }
        }

        public void Pause(string name)
        {
            Sound s = Array.Find(sounds, sound => sound.name == name);

            if (s == null)
            {
                Debug.LogWarning("Sound " + name + " not found !");
                return;
            }

            s.audioSource?.Pause();
        }

        public void Stop(string name)
        {
            Sound s = Array.Find(sounds, sound => sound.name == name);

            if (s == null)
            {
                Debug.LogWarning("Sound " + name + " not found !");
                return;
            }

            
            if (s.fadeOut)
            {
                StartCoroutine(StartFadeOut(s.audioSource, s.fadeOutDuration));
            } 
            else
            {
                s.audioSource?.Stop();
            }
        }

        public static IEnumerator StartFadeIn(AudioSource s, float duration, float targetVolume)
        {
            float currentTime = 0;
            s.volume = 0;
            float start = s.volume;
            while (currentTime < duration)
            {
                currentTime += Time.deltaTime;
                s.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
                yield return null;
            }
            yield break;
        }

        public static IEnumerator StartFadeOut(AudioSource s, float duration)
        {
            float currentTime = 0;
            float start = s.volume;
            while (currentTime < duration)
            {
                currentTime += Time.deltaTime;
                s.volume = Mathf.Lerp(start, 0, currentTime / duration);
                yield return null;
            }
            s.Stop();
            yield break;
        }

        private AudioClip GetRandomClip(AudioClip[] audioClips)
        {
            Debug.Log("----Sound is randomized");
            return audioClips[UnityEngine.Random.Range(0, audioClips.Length)];
        }
    }
}

