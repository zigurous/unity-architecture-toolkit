using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A behavior that can run in any update mode. The update mode can be
    /// changed as needed without occuring any additional performance cost.
    /// </summary>
    public abstract class UpdateBehaviour : MonoBehaviour
    {
        /// <summary>
        /// The update mode of the behavior.
        /// </summary>
        [Tooltip("The update mode of the behavior.")]
        public UpdateMode updateMode = UpdateMode.Update;

        /// <summary>
        /// The custom update strategy to use.
        /// </summary>
        [Tooltip("The custom update strategy to use.")]
        [ConditionalShow(nameof(updateMode), (int)UpdateMode.Custom)]
        public UpdateStrategy customStrategy;

        /// <summary>
        /// The update strategy to use.
        /// </summary>
        private UpdateStrategy strategy;

        #if UNITY_EDITOR
        /// <summary>
        /// Whether the update mode has changed.
        /// </summary>
        private bool dirty;
        #endif

        /// <summary>
        /// Handles behavior updates.
        /// </summary>
        /// <param name="deltaTime">The time since the last frame.</param>
        protected abstract void OnUpdate(float deltaTime);

        /// <summary>
        /// A Unity lifecycle method called when the behavior is enabled.
        /// </summary>
        protected virtual void OnEnable()
        {
            if (strategy != null) {
                strategy.Register(OnUpdate);
            } else {
                UpdateStrategy();
            }
        }

        /// <summary>
        /// A Unity lifecycle method called when the behavior is disabled.
        /// </summary>
        protected virtual void OnDisable()
        {
            if (strategy != null) {
                strategy.Unregister(OnUpdate);
            }
        }

        #if UNITY_EDITOR
        /// <summary>
        /// A Unity lifecycle method called during editor validation.
        /// </summary>
        private void OnValidate()
        {
            if (Application.isPlaying) {
                dirty = true;
            }
        }

        private void Update()
        {
            if (dirty)
            {
                UpdateStrategy();
                dirty = false;
            }
        }
        #endif

        /// <summary>
        /// Changes the update strategy to match the update mode.
        /// </summary>
        private void UpdateStrategy()
        {
            switch (updateMode)
            {
                case UpdateMode.Update:
                    SetStrategy<NormalUpdateStrategy>();
                    break;

                case UpdateMode.FixedUpdate:
                    SetStrategy<FixedUpdateStrategy>();
                    break;

                case UpdateMode.LateUpdate:
                    SetStrategy<LateUpdateStrategy>();
                    break;

                case UpdateMode.Custom:
                    SetCustomStrategy(customStrategy);
                    break;
            }
        }

        /// <summary>
        /// Sets the update strategy to the given type.
        /// </summary>
        /// <typeparam name="T">The type of update strategy to set.</typeparam>
        private void SetStrategy<T>() where T : UpdateStrategy
        {
            // Do nothing if the strategy is already set to the given type
            if (strategy is T) {
                return;
            }

            // Unregister from the existing strategy
            if (strategy != null) {
                strategy.Unregister(OnUpdate);
            }

            // See if the strategy already exists
            strategy = GetComponent<T>();

            // Create a new strategy if it does not exist
            if (strategy == null)
            {
                strategy = gameObject.AddComponent<T>();
                strategy.hideFlags = HideFlags.HideInInspector;
            }

            // Register to the new strategy
            strategy.Register(OnUpdate);
        }

        /// <summary>
        /// Sets the update strategy to the custom strategy.
        /// </summary>
        private void SetCustomStrategy(UpdateStrategy customStrategy)
        {
            // Do nothing if the strategy is already set to the custom strategy
            if (strategy == customStrategy) {
                return;
            }

            // Unregister from the existing strategy
            if (strategy != null) {
                strategy.Unregister(OnUpdate);
            }

            // Register the custom strategy
            strategy = customStrategy;

            if (strategy != null) {
                strategy.Register(OnUpdate);
            }
        }

    }

}
