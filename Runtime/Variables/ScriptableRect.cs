using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A Rect value stored as a ScriptableObject.
    /// </summary>
    [CreateAssetMenu(menuName = "Zigurous/Variables/Rect", order = 9)]
    [HelpURL("https://docs.zigurous.com/com.zigurous.architecture/api/Zigurous.Architecture/ScriptableRect")]
    public class ScriptableRect : ScriptableValue<Rect>
    {
        [SerializeField]
        [Delayed]
        private Rect m_Value;

        /// <inheritdoc/>
        public override Rect value
        {
            get => m_Value;
            set => m_Value = value;
        }

    }

}
