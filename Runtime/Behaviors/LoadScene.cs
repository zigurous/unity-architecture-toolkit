using UnityEngine;
using UnityEngine.SceneManagement;

namespace Zigurous.Architecture
{
    /// <summary>
    /// Loads a scene using a specified set of options.
    /// </summary>
    [AddComponentMenu("Zigurous/Utility/Load Scene")]
    [HelpURL("https://docs.zigurous.com/com.zigurous.architecture/api/Zigurous.Architecture/LoadScene")]
    public sealed class LoadScene : MonoBehaviour
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
        public float delay;

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
                Invoke(nameof(TriggerLoadSceneAsync), delay);
            } else {
                Invoke(nameof(TriggerLoadScene), delay);
            }
        }

        /// <summary>
        /// Loads the scene using the settings provided in the script while
        /// ignoring any delay.
        /// </summary>
        public void LoadImmediate()
        {
            if (async) {
                TriggerLoadSceneAsync();
            } else {
                TriggerLoadScene();
            }
        }

        /// <summary>
        /// Loads the scene synchronously.
        /// </summary>
        private void TriggerLoadScene()
        {
            SceneManager.LoadScene(scene, mode);
        }

        /// <summary>
        /// Loads the scene asynchronously.
        /// </summary>
        /// <returns>The async operation.</returns>
        private AsyncOperation TriggerLoadSceneAsync()
        {
            return SceneManager.LoadSceneAsync(scene, mode);
        }

    }

}
