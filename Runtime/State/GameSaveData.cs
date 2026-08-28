using UnityEngine;

namespace Zigurous.Architecture
{
    [System.Serializable]
    public abstract class GameSaveData
    {
        public virtual string ToJson()
        {
            return JsonUtility.ToJson(this);
        }

    }

}
