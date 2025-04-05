using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A string value stored as a ScriptableObject.
    /// </summary>
    [CreateAssetMenu(menuName = "Zigurous/Variables/String", order = 11)]
    [HelpURL("https://docs.zigurous.com/com.zigurous.architecture/api/Zigurous.Architecture/ScriptableString")]
    public class ScriptableString : ScriptableValue<string>
    {
        [SerializeField]
        [Delayed]
        private string m_Value;

        /// <inheritdoc/>
        public override string value
        {
            get => m_Value;
            set => m_Value = value;
        }

    }

}
