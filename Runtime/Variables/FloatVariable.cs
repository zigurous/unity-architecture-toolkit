using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A float variable saved as a ScriptableObject.
    /// </summary>
    [CreateAssetMenu(menuName = "Zigurous/Variables/Float", order = 4)]
    [HelpURL("https://docs.zigurous.com/com.zigurous.architecture/api/Zigurous.Architecture/FloatVariable")]
    public class FloatVariable : ScriptableVariable<float>
    {
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
