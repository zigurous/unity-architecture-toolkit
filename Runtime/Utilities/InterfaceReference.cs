using UnityEngine;

namespace Zigurous.Architecture
{
    [System.Serializable]
    public struct InterfaceReference<TInterface, TObject> where TObject : Object
    {
        [SerializeField] private TObject m_Target;

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

        public void SetTarget<T>(T target) where T : TObject, TInterface
        {
            m_Target = target;
        }

    }

}
