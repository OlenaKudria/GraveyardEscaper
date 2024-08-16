using UnityEngine;

namespace SceneManagement
{
    public class SceneManager : MonoBehaviour
    {
        private static SceneManager _instance;
        
        public static SceneManager Instance
        {
            get
            {
                if (_instance != null) return _instance;
                _instance = FindObjectOfType<SceneManager>();

                if (_instance != null) return _instance;

                CreateNewInstance();
                
                return _instance;
            }
        }
        
        private void Awake()
        {
            if (_instance != null)
            {
                Destroy(gameObject);
                return;
            }

            _instance = this;
        }

        public void LoadScene(Scenes scene) => UnityEngine.SceneManagement.SceneManager.LoadScene(scene.ToString());
        
        private static void CreateNewInstance()
        {
            GameObject obj = new GameObject("SceneManager");

            obj.AddComponent<SceneManager>();
            
            DontDestroyOnLoad(_instance);
        }
    }
}