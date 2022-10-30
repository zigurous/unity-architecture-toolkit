using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// Sets the target frame rate of the application.
    /// </summary>
    [AddComponentMenu("Zigurous/Utility/Target Frame Rate")]
    public sealed class TargetFrameRate : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("The target frame rate of the application.")]
        private int m_TargetFrameRate = -1;

        /// <summary>
        /// The target frame rate of the application.
        /// </summary>
        public int targetFrameRate
        {
            get => m_TargetFrameRate;
            set
            {
                m_TargetFrameRate = value;
                Application.targetFrameRate = value;
            }
        }

        private void OnValidate()
        {
            if (Application.isPlaying && enabled) {
                Application.targetFrameRate = targetFrameRate;
            }
        }

        private void OnEnable()
        {
            Application.targetFrameRate = targetFrameRate;
        }

    }

}
