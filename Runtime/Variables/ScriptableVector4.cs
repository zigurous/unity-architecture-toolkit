using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A Vector4 value stored as a ScriptableObject.
    /// </summary>
    [CreateAssetMenu(menuName = "Zigurous/Variables/Vector4", order = 17)]
    [HelpURL("https://docs.zigurous.com/com.zigurous.architecture/api/Zigurous.Architecture/ScriptableVector4")]
    public class ScriptableVector4 : ScriptableValue<Vector4>
    {
        [SerializeField]
        [Delayed]
        private Vector4 m_Value;

        /// <inheritdoc/>
        public override Vector4 value
        {
            get => m_Value;
            set => m_Value = value;
        }

    }

}
