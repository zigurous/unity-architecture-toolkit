using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// An update strategy executed during the late update loop.
    /// </summary>
    [AddComponentMenu("")]
    [HelpURL("https://docs.zigurous.com/com.zigurous.architecture/api/Zigurous.Architecture/LateUpdateStrategy")]
    public sealed class LateUpdateStrategy : UpdateStrategy
    {
        private void LateUpdate()
        {
            Execute(Time.deltaTime);
        }

    }

}
