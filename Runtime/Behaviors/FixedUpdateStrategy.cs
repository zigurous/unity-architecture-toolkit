using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// An update strategy executed during the fixed update loop.
    /// </summary>
    [AddComponentMenu("")]
    [HelpURL("https://docs.zigurous.com/com.zigurous.architecture/api/Zigurous.Architecture/FixedUpdateStrategy")]
    public sealed class FixedUpdateStrategy : UpdateStrategy
    {
        private void FixedUpdate()
        {
            Execute(Time.fixedDeltaTime);
        }

    }

}
