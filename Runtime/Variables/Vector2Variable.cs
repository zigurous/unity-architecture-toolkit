using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A Vector2 variable saved as a ScriptableObject.
    /// </summary>
    [CreateAssetMenu(menuName = "Zigurous/Variables/Vector2")]
    [HelpURL("https://docs.zigurous.com/com.zigurous.architecture/api/Zigurous.Architecture/Vector2Variable")]
    public class Vector2Variable : ScriptableVariable<Vector2>
    {
        /// <summary>
        /// The value of the variable.
        /// </summary>
        [SerializeField]
        [Tooltip("The value of the variable.")]
        private Vector2 m_Value;

        /// <inheritdoc/>
        public override Vector2 value
        {
            get => m_Value;
            set => m_Value = value;
        }

    }

}
