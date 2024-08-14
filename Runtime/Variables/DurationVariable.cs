using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A variable saved as a ScriptableObject to represent a duration.
    /// </summary>
    [CreateAssetMenu(menuName = "Zigurous/Variables/Duration", order = 3)]
    [HelpURL("https://docs.zigurous.com/com.zigurous.architecture/api/Zigurous.Architecture/DurationVariable")]
    public class DurationVariable : ScriptableVariable<float>
    {
        [SerializeField]
        [Tooltip("The duration of the cooldown.")]
        private float m_Duration;

        /// <inheritdoc/>
        public override float value
        {
            get => m_Duration;
            set => m_Duration = value;
        }

    }

}
