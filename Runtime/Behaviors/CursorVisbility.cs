using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// Sets the visibility of the cursor.
    /// </summary>
    [AddComponentMenu("Zigurous/Utility/Cursor Visibility")]
    [HelpURL("https://docs.zigurous.com/com.zigurous.architecture/api/Zigurous.Architecture/CursorVisibility")]
    public sealed class CursorVisbility : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("The visibility of the cursor when the script is enabled.")]
        private bool m_VisibleOnEnable = false;

        [SerializeField]
        [Tooltip("The visibility of the cursor when the script is disabled.")]
        private bool m_VisibleOnDisable = true;

        /// <summary>
        /// The visibility of the cursor when the script is enabled.
        /// </summary>
        public bool visibleOnEnable
        {
            get => m_VisibleOnEnable;
            set
            {
                m_VisibleOnEnable = value;

                if (Application.isPlaying && enabled) {
                    Cursor.visible = m_VisibleOnEnable;
                }
            }
        }

        /// <summary>
        /// The visibility of the cursor when the script is disabled.
        /// </summary>
        public bool visibleOnDisable
        {
            get => m_VisibleOnDisable;
            set
            {
                m_VisibleOnDisable = value;

                if (Application.isPlaying && !enabled) {
                    Cursor.visible = m_VisibleOnDisable;
                }
            }
        }

        private void OnEnable()
        {
            Cursor.visible = visibleOnEnable;
        }

        private void OnDisable()
        {
            Cursor.visible = visibleOnDisable;
        }

    }

}
