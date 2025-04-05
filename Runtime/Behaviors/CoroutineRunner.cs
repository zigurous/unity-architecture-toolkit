using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A persistent singleton behavior that can be used to run coroutines.
    /// </summary>
    [AddComponentMenu("")]
    [HelpURL("https://docs.zigurous.com/com.zigurous.architecture/api/Zigurous.Architecture/CoroutineRunner")]
    public sealed class CoroutineRunner : PersistentSingletonBehaviour<CoroutineRunner>
    {
    }

}
