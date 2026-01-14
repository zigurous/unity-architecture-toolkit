using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A ScriptableObject that represents an ID.
    /// </summary>
    [CreateAssetMenu(menuName = "Zigurous/Utils/Identifier")]
    [HelpURL("https://docs.zigurous.com/com.zigurous.architecture/api/Zigurous.Architecture/ScriptableIdentifier")]
    public class ScriptableIdentifier : ScriptableObject
    {
        /// <summary>
        /// The instance ID.
        /// </summary>
        public int id => GetInstanceID();
    }

}
