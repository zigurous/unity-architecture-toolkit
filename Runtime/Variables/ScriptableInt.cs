using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// An int value stored as a ScriptableObject.
    /// </summary>
    [CreateAssetMenu(menuName = "Zigurous/Variables/Int", order = 5)]
    [HelpURL("https://docs.zigurous.com/com.zigurous.architecture/api/Zigurous.Architecture/ScriptableInt")]
    public class ScriptableInt : ScriptableValue<int>
    {
        [SerializeField]
        [Delayed]
        private int m_Value;

        /// <inheritdoc/>
        public override int value
        {
            get => m_Value;
            set => m_Value = value;
        }

    }

}
