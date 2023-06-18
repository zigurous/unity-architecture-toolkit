using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A Bounds variable saved as a ScriptableObject.
    /// </summary>
    [CreateAssetMenu(menuName = "Zigurous/Variables/Bounds")]
    public class BoundsVariable : ScriptableVariable<Bounds>
    {
        /// <summary>
        /// The value of the variable.
        /// </summary>
        [SerializeField]
        [Tooltip("The value of the variable.")]
        private Bounds m_Value;

        /// <inheritdoc/>
        public override Bounds value
        {
            get => m_Value;
            set => m_Value = value;
        }

    }

}
