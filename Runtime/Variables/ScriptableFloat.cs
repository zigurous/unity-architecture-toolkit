using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A float value stored as a ScriptableObject.
    /// </summary>
    [CreateAssetMenu(menuName = "Zigurous/Variables/Float", order = 4)]
    [HelpURL("https://docs.zigurous.com/com.zigurous.architecture/api/Zigurous.Architecture/ScriptableFloat")]
    public class ScriptableFloat : ScriptableValue<float>
    {
        [SerializeField]
        [Delayed]
        private float m_Value;

        /// <inheritdoc/>
        public override float value
        {
            get => m_Value;
            set => m_Value = value;
        }

    }

}
