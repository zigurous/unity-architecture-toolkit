using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// The base class for all game save data.
    /// </summary>
    [System.Serializable]
    public abstract class GameSaveData
    {
        /// <summary>
        /// Converts the save data to JSON format.
        /// </summary>
        /// <returns>The JSON string representing the save data.</returns>
        public virtual string ToJson()
        {
            return JsonUtility.ToJson(this);
        }

    }

}
