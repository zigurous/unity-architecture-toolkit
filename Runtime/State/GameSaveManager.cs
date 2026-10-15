using System;
using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// Manages a set amount of save profiles for the game. This class is
    /// particularly useful for handling save profiles on the main menu.
    /// </summary>
    public class GameSaveManager : GameSaveManager<GameSave>
    {
    }

    /// <summary>
    /// Manages a set amount of save profiles for the game. This class is
    /// particularly useful for handling save profiles on the main menu.
    /// </summary>
    /// <typeparam name="T">The type of game save.</typeparam>
    public abstract class GameSaveManager<T> : MonoBehaviour
        where T : GameSave
    {
        /// <summary>
        /// Contextual info about a save profile, e.g., whether it exists, the
        /// last save date/time, etc.
        /// </summary>
        public struct GameSaveContext
        {
            /// <summary>
            /// The save profile for the context.
            /// </summary>
            public T profile;

            /// <summary>
            /// The index of the save profile.
            /// </summary>
            public int index;

            /// <summary>
            /// The last date/time the profile was saved.
            /// </summary>
            public DateTime? lastSaveDateTime;

            /// <summary>
            /// Whether the save profile exists or not.
            /// </summary>
            public bool exists;

            /// <summary>
            /// Initializes the context for the given save profile.
            /// </summary>
            /// <param name="profile">The save profile for the context.</param>
            /// <param name="index">The index of the save profile.</param>
            public GameSaveContext(T profile, int index)
            {
                this.profile = profile;
                this.index = index;
                this.exists = profile.Exists();
                this.lastSaveDateTime = exists ? profile.GetLastWriteTime() : null;
            }

        }

        [SerializeField]
        [Tooltip("Loads the save context on start.")]
        private bool initializeOnStart = true;

        [SerializeField]
        [Tooltip("The save profiles to manage. The length of the array is the maximum amount of saves that can be made.")]
        private T[] profiles;

        private GameSaveContext[] context;

        /// <summary>
        /// The amount of save profiles being used.
        /// </summary>
        public int UsedSaveCount
        {
            get
            {
                if (context == null) {
                    Initialize();
                }

                int count = 0;

                for (int i = 0; i < context.Length; i++)
                {
                    if (context[i].exists) {
                        count++;
                    }
                }

                return count;
            }
        }

        /// <summary>
        /// The amount of save profiles not yet used.
        /// </summary>
        public int UnusedSaveCount
        {
            get
            {
                if (context == null) {
                    Initialize();
                }

                int count = 0;

                for (int i = 0; i < context.Length; i++)
                {
                    if (!context[i].exists) {
                        count++;
                    }
                }

                return count;
            }
        }

        private void Start()
        {
            if (initializeOnStart) {
                Initialize();
            }
        }

        /// <summary>
        /// Loads the save context for each save profile.
        /// </summary>
        public void Initialize()
        {
            if (context == null) {
                context = new GameSaveContext[profiles.Length];
            } else if (context.Length != profiles.Length) {
                Array.Resize(ref context, profiles.Length);
            }

            for (int i = 0; i < profiles.Length; i++) {
                context[i] = new GameSaveContext(profiles[i], i);
            }
        }

        /// <summary>
        /// Gets the save context for a save profile.
        /// </summary>
        /// <param name="profile">The save profile to get the context of.</param>
        /// <returns>The save context for the profile.</returns>
        public GameSaveContext GetContext(T profile)
        {
            if (context == null) {
                Initialize();
            }

            for (int i = 0; i < context.Length; i++)
            {
                if (context[i].profile == profile) {
                    return context[i];
                }
            }

            return default;
        }

        /// <summary>
        /// Gets the save context for the given save index.
        /// </summary>
        /// <param name="index">The index of a save profile.</param>
        /// <returns>The save context for the profile at the given index.</returns>
        public GameSaveContext GetContext(int index)
        {
            if (context == null) {
                Initialize();
            }

            if (index < 0 || index >= context.Length) {
                return default;
            } else {
                return context[index];
            }
        }

        /// <summary>
        /// Gets the most recently saved profile.
        /// </summary>
        /// <returns>The most recently saved profile, or null if no save exists.</returns>
        public T GetLatestSave()
        {
            if (context == null) {
                Initialize();
            }

            T latestSave = null;
            DateTime latestDateTime = DateTime.MinValue;

            for (int i = 0; i < context.Length; i++)
            {
                var saveContext = context[i];

                if (saveContext.lastSaveDateTime.HasValue && saveContext.lastSaveDateTime.Value > latestDateTime)
                {
                    latestSave = saveContext.profile;
                    latestDateTime = saveContext.lastSaveDateTime.Value;
                }
            }

            return latestSave;
        }

        /// <summary>
        /// Gets the oldest saved profile.
        /// </summary>
        /// <returns>The oldest saved profile, or null if no save exists.</returns>
        public T GetOldestSave()
        {
            if (context == null) {
                Initialize();
            }

            T oldestSave = null;
            DateTime oldestDateTime = DateTime.MaxValue;

            for (int i = 0; i < context.Length; i++)
            {
                var saveContext = context[i];

                if (saveContext.lastSaveDateTime.HasValue && saveContext.lastSaveDateTime < oldestDateTime)
                {
                    oldestSave = saveContext.profile;
                    oldestDateTime = saveContext.lastSaveDateTime.Value;
                }
            }

            return oldestSave;
        }

        /// <summary>
        /// Gets the next available unused save profile.
        /// </summary>
        /// <returns>An unused save profile, or null if no unused profile exists.</returns>
        public T GetUnusedSave()
        {
            if (context == null) {
                Initialize();
            }

            for (int i = 0; i < context.Length; i++)
            {
                if (!context[i].exists) {
                    return context[i].profile;
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the most recently saved profile.
        /// </summary>
        /// <param name="profile">The most recently saved profile as an output.</param>
        /// <returns>True if a most recent save exists, false otherwise.</returns>
        public bool TryGetLatestSave(out T profile)
        {
            profile = GetLatestSave();
            return profile != null;
        }

        /// <summary>
        /// Gets the oldest saved profile.
        /// </summary>
        /// <param name="profile">The oldest saved profile as an output.</param>
        /// <returns>True if an oldest save exists, false otherwise.</returns>
        public bool TryGetOldestSave(out T profile)
        {
            profile = GetOldestSave();
            return profile != null;
        }

        /// <summary>
        /// Gets the next available unused save profile.
        /// </summary>
        /// <param name="profile">The next available unused save profile as an output.</param>
        /// <returns>True if an unused save exists, false otherwise.</returns>
        public bool TryGetUnusedSave(out T profile)
        {
            profile = GetUnusedSave();
            return profile != null;
        }

        /// <summary>
        /// Checks if an unused save profile exists.
        /// </summary>
        /// <returns>True if an unused save profile exists, false otherwise.</returns>
        public bool HasUnusedSave()
        {
            if (context == null) {
                Initialize();
            }

            for (int i = 0; i < context.Length; i++)
            {
                if (!context[i].exists) {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Checks if any save profile has been made.
        /// </summary>
        /// <returns>True if a save profile has been made, false otherwise.</returns>
        public bool HasAnySave()
        {
            if (context == null) {
                Initialize();
            }

            for (int i = 0; i < context.Length; i++)
            {
                if (context[i].exists) {
                    return true;
                }
            }

            return false;
        }

    }

}
