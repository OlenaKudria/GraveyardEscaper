using Audio;
using SceneManagement;
using UnityEngine;

namespace Ui.General
{
    public class GeneralUiManager : MonoBehaviour
    {
        public void PlaySfx(AudioClip clip)
        {
            AudioManager.Instance.PlaySfx(clip);
        }

        public void LoadMenu()
        {
            SceneManager.Instance.LoadScene(Scenes.Menu);
        }
        
        public void LoadGame()
        {
            SceneManager.Instance.LoadScene(Scenes.Game);
        }
    }
}
