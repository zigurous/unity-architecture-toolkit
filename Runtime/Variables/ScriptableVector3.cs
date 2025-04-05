using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A Vector3 value stored as a ScriptableObject.
    /// </summary>
    [CreateAssetMenu(menuName = "Zigurous/Variables/Vector3", order = 15)]
    [HelpURL("https://docs.zigurous.com/com.zigurous.architecture/api/Zigurous.Architecture/ScriptableVector3")]
    public class ScriptableVector3 : ScriptableValue<Vector3>
    {
        [SerializeField]
        [Delayed]
        private Vector3 m_Value;

        /// <inheritdoc/>
        public override Vector3 value
        {
            get => m_Value;
            set => m_Value = value;
        }

    }

}
