using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// An update strategy executed during the normal update loop.
    /// </summary>
    [AddComponentMenu("")]
    public sealed class NormalUpdateStrategy : UpdateStrategy
    {
        private void Update()
        {
            Execute(Time.deltaTime);
        }

    }

}
