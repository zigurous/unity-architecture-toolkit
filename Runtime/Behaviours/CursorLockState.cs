using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// Sets the lock state of the cursor when the behaviour is enabled and disabled.
    /// </summary>
    [AddComponentMenu("Zigurous/Utility/Cursor Lock State")]
    [HelpURL("https://docs.zigurous.com/com.zigurous.architecture/api/Zigurous.Architecture/CursorLockState")]
    public sealed class CursorLockState : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("The visibility of the cursor when the script is enabled.")]
        private CursorLockMode m_LockStateOnEnable = CursorLockMode.Locked;

        [SerializeField]
        [Tooltip("The visibility of the cursor when the script is disabled.")]
        private CursorLockMode m_LockStateOnDisable = CursorLockMode.Confined;

        /// <summary>
        /// The visibility of the cursor when the script is enabled.
        /// </summary>
        public CursorLockMode lockStateOnEnable
        {
            get => m_LockStateOnEnable;
            set
            {
                m_LockStateOnEnable = value;

                if (Application.isPlaying && enabled) {
                    Cursor.lockState = m_LockStateOnEnable;
                }
            }
        }

        /// <summary>
        /// The visibility of the cursor when the script is disabled.
        /// </summary>
        public CursorLockMode lockStateOnDisable
        {
            get => m_LockStateOnDisable;
            set
            {
                m_LockStateOnDisable = value;

                if (Application.isPlaying && !enabled) {
                    Cursor.lockState = m_LockStateOnDisable;
                }
            }
        }

        private void OnEnable()
        {
            Cursor.lockState = lockStateOnEnable;
        }

        private void OnDisable()
        {
            Cursor.lockState = lockStateOnDisable;
        }

    }

}
