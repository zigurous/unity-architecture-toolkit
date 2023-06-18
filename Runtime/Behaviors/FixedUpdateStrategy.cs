using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// An update strategy executed during the fixed update loop.
    /// </summary>
    [AddComponentMenu("")]
    public sealed class FixedUpdateStrategy : UpdateStrategy
    {
        private void FixedUpdate()
        {
            Execute(Time.fixedDeltaTime);
        }

    }

}
