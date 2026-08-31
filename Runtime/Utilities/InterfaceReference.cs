using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A serialized referenced to a C# interface.
    /// </summary>
    [System.Serializable]
    public struct InterfaceReference<TInterface, TObject> where TObject : Object
    {
        [SerializeField]
        [Tooltip("The target object conforming to the interface.")]
        private TObject m_Target;

        /// <summary>
        /// The dereferenced interface.
        /// </summary>
        public readonly TInterface Value
        {
            get
            {
                if (m_Target != null && m_Target is TInterface value) {
                    return value;
                } else {
                    return default;
                }
            }
        }

        /// <summary>
        /// Sets the interface reference to the provided target object.
        /// </summary>
        /// <typeparam name="T">The type of object that conforms to the interface.</typeparam>
        /// <param name="target">The target object conforming to the interface.</param>
        public void SetTarget<T>(T target) where T : TObject, TInterface
        {
            m_Target = target;
        }

    }

}
