using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// Extension methods for Unity Behaviors.
    /// </summary>
    public static class BehaviourExtensions
    {
        /// <summary>
        /// Sets the enabled state of a behavior.
        /// </summary>
        /// <param name="behavior">The behavior to enable or disable.</param>
        /// <param name="enabled">The enabled state to set.</param>
        public static void SetEnabled(this Behaviour behavior, bool enabled)
        {
            behavior.enabled = enabled;
        }

        /// <summary>
        /// Sets the enabled state of an array of behaviors.
        /// </summary>
        /// <param name="behaviors">The behaviors to enable or disable.</param>
        /// <param name="enabled">The enabled state to set.</param>
        public static void SetEnabled(this Behaviour[] behaviors, bool enabled)
        {
            for (int i = 0; i < behaviors.Length; i++) {
                behaviors[i].enabled = enabled;
            }
        }

        /// <summary>
        /// Enables an array of behaviors.
        /// </summary>
        /// <param name="behaviors">The behaviors to enable.</param>
        public static void EnableAll(this Behaviour[] behaviors)
        {
            for (int i = 0; i < behaviors.Length; i++) {
                behaviors[i].enabled = true;
            }
        }

        /// <summary>
        /// Disables an array of behaviors.
        /// </summary>
        /// <param name="behaviors">The behaviors to disable.</param>
        public static void DisableAll(this Behaviour[] behaviors)
        {
            for (int i = 0; i < behaviors.Length; i++) {
                behaviors[i].enabled = false;
            }
        }

    }

}
