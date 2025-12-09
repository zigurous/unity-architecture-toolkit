using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A ScriptableObject that references a scene by name and/or build index.
    /// </summary>
    [CreateAssetMenu(menuName = "Zigurous/Utils/Scene Reference")]
    [HelpURL("https://docs.zigurous.com/com.zigurous.architecture/api/Zigurous.Architecture/SceneReference")]
    public class SceneReference : ScriptableObject
    {
        [SerializeField]
        [Tooltip("The name of the scene.")]
        private string m_SceneName;

        [SerializeField]
        [Tooltip("The index of the scene in the build settings.")]
        private int m_BuildIndex;

        /// <summary>
        /// The name of the scene.
        /// </summary>
        public string sceneName
        {
            get => m_SceneName;
            set => m_SceneName = value;
        }

        /// <summary>
        /// The index of the scene in the build settings.
        /// </summary>
        public int buildIndex
        {
            get => m_BuildIndex;
            set => m_BuildIndex = value;
        }

    }

}
