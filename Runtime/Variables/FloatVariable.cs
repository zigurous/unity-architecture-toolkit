using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A float variable saved as a ScriptableObject.
    /// </summary>
    [CreateAssetMenu(menuName = "Zigurous/Variables/Float")]
    public class FloatVariable : ScriptableVariable<float>
    {
        /// <summary>
        /// The value of the variable.
        /// </summary>
        [SerializeField]
        [Tooltip("The value of the variable.")]
        private float m_Value;

        /// <inheritdoc/>
        public override float value
        {
            get => m_Value;
            set => m_Value = value;
        }

    }

}
