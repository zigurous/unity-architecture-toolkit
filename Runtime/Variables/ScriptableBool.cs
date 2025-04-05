using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A boolean value stored as a ScriptableObject.
    /// </summary>
    [CreateAssetMenu(menuName = "Zigurous/Variables/Bool", order = 0)]
    [HelpURL("https://docs.zigurous.com/com.zigurous.architecture/api/Zigurous.Architecture/ScriptableBool")]
    public class ScriptableBool : ScriptableValue<bool>
    {
        [SerializeField]
        [Delayed]
        private bool m_Value;

        /// <inheritdoc/>
        public override bool value
        {
            get => m_Value;
            set => m_Value = value;
        }

    }

}
