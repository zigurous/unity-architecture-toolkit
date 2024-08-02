using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// An update strategy executed during the normal update loop.
    /// </summary>
    [AddComponentMenu("")]
    [HelpURL("https://docs.zigurous.com/com.zigurous.architecture/api/Zigurous.Architecture/NormalUpdateStrategy")]
    public sealed class NormalUpdateStrategy : UpdateStrategy
    {
        private void Update()
        {
            Execute(Time.deltaTime);
        }

    }

}
