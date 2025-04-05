using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A Bounds value stored as a ScriptableObject.
    /// </summary>
    [CreateAssetMenu(menuName = "Zigurous/Variables/Bounds", order = 1)]
    [HelpURL("https://docs.zigurous.com/com.zigurous.architecture/api/Zigurous.Architecture/ScriptableBounds")]
    public class ScriptableBounds : ScriptableValue<Bounds>
    {
        [SerializeField]
        [Delayed]
        private Bounds m_Value;

        /// <inheritdoc/>
        public override Bounds value
        {
            get => m_Value;
            set => m_Value = value;
        }

    }

}
