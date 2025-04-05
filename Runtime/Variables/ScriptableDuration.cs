using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A duration value stored as a ScriptableObject. Durations are represented
    /// as floating-point values.
    /// </summary>
    [CreateAssetMenu(menuName = "Zigurous/Variables/Duration", order = 3)]
    [HelpURL("https://docs.zigurous.com/com.zigurous.architecture/api/Zigurous.Architecture/ScriptableDuration")]
    public class ScriptableDuration : ScriptableValue<float>
    {
        [SerializeField]
        [Delayed]
        private float m_Duration;

        /// <inheritdoc/>
        public override float value
        {
            get => m_Duration;
            set => m_Duration = value;
        }

    }

}
