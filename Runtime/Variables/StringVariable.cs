using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A string variable saved as a ScriptableObject.
    /// </summary>
    [CreateAssetMenu(menuName = "Zigurous/Variables/String")]
    [HelpURL("https://docs.zigurous.com/com.zigurous.architecture/api/Zigurous.Architecture/StringVariable")]
    public class StringVariable : ScriptableVariable<string>
    {
        /// <summary>
        /// The value of the variable.
        /// </summary>
        [SerializeField]
        [Tooltip("The value of the variable.")]
        private string m_Value;

        /// <inheritdoc/>
        public override string value
        {
            get => m_Value;
            set => m_Value = value;
        }

    }

}
