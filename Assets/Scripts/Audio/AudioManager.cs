using System;
using UnityEngine;

namespace Audio
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance
        {
            get
            {
                if (instance != null) return instance;
                instance = FindObjectOfType<AudioManager>();

                if (instance != null) return instance;

                CreateNewInstance();
                
                return instance;
            }
        }
        
        public bool IsMusicOn
        {
            get => Convert.ToBoolean(PlayerPrefs.GetInt(MusicKey, 1));
            set
            {
                PlayerPrefs.SetInt(MusicKey, Convert.ToInt32(value));
                PlayerPrefs.Save();
                
                if (MusicSource != null) 
                    MusicSource.mute = !value;
            }
        }
        
        public bool IsSoundOn
        {
            get => Convert.ToBoolean(PlayerPrefs.GetInt(SoundKey, 1));
            set
            {
                PlayerPrefs.SetInt(SoundKey, Convert.ToInt32(value));
                PlayerPrefs.Save();
                
                if (SoundSource != null) 
                    SoundSource.mute = !value;
            }
        }
        
        public AudioSource MusicSource { get; private set; }
        public AudioSource SoundSource { get; private set; }
        
        private const string SoundKey = "Sound";
        private const string MusicKey = "Music";
        
        private static AudioManager instance;

        private void Awake()
        {
            if (instance != null)
            {
                Destroy(gameObject);
                return;
            }

            instance = this;
        }

        private void Start()
        {
            CheckAudioSources();
        }

        public void PlaySfx(AudioClip clip)
        {
            SoundSource.clip = clip;
           
            SoundSource.PlayOneShot(clip, 0.5f);
        }

        public void PlayMusic(AudioClip clip)
        {
            MusicSource.clip = clip;
            MusicSource.playOnAwake = true;
            MusicSource.loop = true;
            MusicSource.volume = 1f;
            
            MusicSource.Play();
        }

        private void CheckAudioSources()
        {
            MusicSource.mute = IsMusicOn == false;
            SoundSource.mute = IsSoundOn == false;
        }

        private static void CreateNewInstance()
        {
            GameObject obj = new GameObject("AudioManager");

            obj.AddComponent<AudioManager>();

            GameObject musicObj = new GameObject("Music");
            musicObj.transform.SetParent(obj.transform);

            GameObject sfxObj = new GameObject("SFX");
            sfxObj.transform.SetParent(obj.transform);

            instance.MusicSource = musicObj.AddComponent<AudioSource>();
            instance.SoundSource = sfxObj.AddComponent<AudioSource>(); 
            
            DontDestroyOnLoad(instance);
        }
    }
}