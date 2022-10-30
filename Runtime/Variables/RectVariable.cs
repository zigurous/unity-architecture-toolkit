using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A Rect variable saved as a ScriptableObject.
    /// </summary>
    [CreateAssetMenu(menuName = "Zigurous/Variables/Rect")]
    [HelpURL("https://docs.zigurous.com/com.zigurous.architecture/api/Zigurous.Architecture/RectVariable")]
    public class RectVariable : ScriptableVariable<Rect>
    {
        /// <summary>
        /// The value of the variable.
        /// </summary>
        [SerializeField]
        [Tooltip("The value of the variable.")]
        private Rect m_Value;

        /// <inheritdoc/>
        public override Rect value
        {
            get => m_Value;
            set => m_Value = value;
        }

    }

}
