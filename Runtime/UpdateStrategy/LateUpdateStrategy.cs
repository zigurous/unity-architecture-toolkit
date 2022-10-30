using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// An update strategy executed during the late update loop.
    /// </summary>
    [AddComponentMenu("")]
    public sealed class LateUpdateStrategy : UpdateStrategy
    {
        private void LateUpdate()
        {
            Execute(Time.deltaTime);
        }

    }

}
