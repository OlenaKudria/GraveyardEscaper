using Audio;
using UnityEngine;

namespace StartUp
{
    public class StartMusic : MonoBehaviour
    {
        [SerializeField] private AudioClip clip;

        private void Awake()
        {
            PlayMusic();
        }

        private void PlayMusic()
        {
            if (AudioManager.Instance.MusicSource.clip == null)
                AudioManager.Instance.PlayMusic(clip);
        }
    }
}