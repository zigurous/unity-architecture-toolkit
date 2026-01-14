using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// Creates and provides a key value store for the game object.
    /// </summary>
    [DefaultExecutionOrder(-1000)]
    public class StoreProvider : MonoBehaviour
    {
        /// <summary>
        /// The id of the key value store.
        /// </summary>
        public int storeId => m_PersistentId != null ? m_PersistentId.id : gameObject.GetInstanceID();

        [SerializeField]
        [Tooltip("An optional id that causes the store to stay in memory after the game object is destroyed.")]
        private ScriptableIdentifier m_PersistentId;

        /// <summary>
        /// An optional id that causes the store to stay in memory after the
        /// game object is destroyed.
        /// </summary>
        public ScriptableIdentifier persistentId => m_PersistentId;

        /// <summary>
        /// A reference to the key value store (Read only).
        /// </summary>
        public KeyValueStore store { get; private set; }

        /// <summary>
        /// A Unity lifecycle method called when the behavior is initialized.
        /// </summary>
        protected virtual void Awake()
        {
            store = StoreManager.Instance.GetStore(storeId);
        }

        /// <summary>
        /// A Unity lifecycle method called when the behavior is destroyed.
        /// </summary>
        protected virtual void OnDestroy()
        {
            if (m_PersistentId == null && StoreManager.IsLoaded) {
                StoreManager.Instance.Delete(storeId);
            }

            store = null;
        }

    }

}
