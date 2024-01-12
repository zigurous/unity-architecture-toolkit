using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A reference to a scene by name and/or build index.
    /// </summary>
    [CreateAssetMenu(menuName = "Zigurous/Scene Reference")]
    [HelpURL("https://docs.zigurous.com/com.zigurous.architecture/api/Zigurous.Architecture/SceneReference")]
    public class SceneReference : ScriptableObject
    {
        /// <summary>
        /// The name of the scene.
        /// </summary>
        [Tooltip("The name of the scene.")]
        public string sceneName;

        /// <summary>
        /// The index of the scene in the build settings.
        /// </summary>
        [Tooltip("The index of the scene in the build settings.")]
        public int buildIndex;
    }

}
