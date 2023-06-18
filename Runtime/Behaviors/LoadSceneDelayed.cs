using UnityEngine;
using UnityEngine.SceneManagement;

namespace Zigurous.Architecture
{
    /// <summary>
    /// Loads a scene after a set delay.
    /// </summary>
    [AddComponentMenu("Zigurous/Utility/Load Scene Delayed")]
    public sealed class LoadSceneDelayed : MonoBehaviour
    {
        /// <summary>
        /// The mode to use for loading the scene.
        /// </summary>
        [Tooltip("The mode to use for loading the scene.")]
        public LoadSceneMode mode;

        /// <summary>
        /// The name of the scene to load.
        /// </summary>
        [Tooltip("The name of the scene to load.")]
        public string scene;

        /// <summary>
        /// The delay in seconds before loading the scene.
        /// </summary>
        [Tooltip("The delay in seconds before loading the scene.")]
        public float delay = 3f;

        /// <summary>
        /// Loads the scene when the script starts.
        /// </summary>
        [Tooltip("Loads the scene when the script starts.")]
        public bool loadOnStart = true;

        /// <summary>
        /// Loads the scene asyncronously in the background.
        /// </summary>
        [Tooltip("Loads the scene asyncronously in the background.")]
        public bool async = false;

        /// <summary>
        /// A Unity lifecycle method called the first frame the behavior is enabled.
        /// </summary>
        private void Start()
        {
            if (loadOnStart) {
                Load();
            }
        }

        /// <summary>
        /// Loads the scene using the settings provided in the script.
        /// </summary>
        public void Load()
        {
            if (async) {
                Invoke(nameof(LoadSceneAsync), delay);
            } else {
                Invoke(nameof(LoadScene), delay);
            }
        }

        /// <summary>
        /// Loads the scene using the settings provided in the script while
        /// ignoring the delay.
        /// </summary>
        public void LoadImmediate()
        {
            if (async) {
                LoadSceneAsync();
            } else {
                LoadScene();
            }
        }

        /// <summary>
        /// Loads the scene synchronously.
        /// </summary>
        private void LoadScene()
        {
            SceneManager.LoadScene(scene, mode);
        }

        /// <summary>
        /// Loads the scene asynchronously.
        /// </summary>
        /// <returns>The async operation.</returns>
        private AsyncOperation LoadSceneAsync()
        {
            return SceneManager.LoadSceneAsync(scene, mode);
        }

    }

}
