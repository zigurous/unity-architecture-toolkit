using System;
using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// Manages a set amount of save profiles for the game.
    /// </summary>
    public sealed class GameSaveManager : MonoBehaviour
    {
        /// <summary>
        /// Contextual info about a save file, e.g., whether it exists, its last
        /// save date/time, etc.
        /// </summary>
        public struct GameSaveContext
        {
            /// <summary>
            /// The save file for the profile.
            /// </summary>
            public GameSave saveFile;

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
            /// <param name="profile">The save profile to initialize.</param>
            public GameSaveContext(GameSave profile)
            {
                saveFile = profile;
                exists = profile.Exists();
                lastSaveDateTime = exists ? profile.GetLastWriteTime() : null;
            }

        }

        [SerializeField]
        [Tooltip("The save files being managed. The game will not allow more save profiles than provided here.")]
        private GameSave[] saveFiles;

        [SerializeField]
        [Tooltip("Loads the save context on start.")]
        private bool initializeOnStart = true;

        private GameSaveContext[] context;

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
                context = new GameSaveContext[saveFiles.Length];
            } else if (context.Length != saveFiles.Length) {
                Array.Resize(ref context, saveFiles.Length);
            }

            for (int i = 0; i < saveFiles.Length; i++)
            {
                GameSave saveFile = saveFiles[i];
                context[i] = new GameSaveContext(saveFile);
            }
        }

        /// <summary>
        /// Gets the save context for a save profile.
        /// </summary>
        /// <param name="profile">The save profile to get the context of.</param>
        /// <returns>The save context for the profile.</returns>
        public GameSaveContext GetContext(GameSave profile)
        {
            if (context == null) {
                Initialize();
            }

            for (int i = 0; i < context.Length; i++)
            {
                if (context[i].saveFile == profile) {
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
        /// <returns>The most recently saved profile.</returns>
        public GameSave GetLatestSave()
        {
            if (context == null) {
                Initialize();
            }

            GameSave latestSave = null;
            DateTime latestDateTime = DateTime.MinValue;

            for (int i = 0; i < context.Length; i++)
            {
                var saveContext = context[i];

                if (saveContext.lastSaveDateTime.HasValue && saveContext.lastSaveDateTime.Value > latestDateTime)
                {
                    latestSave = saveContext.saveFile;
                    latestDateTime = saveContext.lastSaveDateTime.Value;
                }
            }

            return latestSave;
        }

        /// <summary>
        /// Gets the oldest saved profile.
        /// </summary>
        /// <returns>The oldest saved profile.</returns>
        public GameSave GetOldestSave()
        {
            if (context == null) {
                Initialize();
            }

            GameSave oldestSave = null;
            DateTime oldestDateTime = DateTime.MaxValue;

            for (int i = 0; i < context.Length; i++)
            {
                var saveContext = context[i];

                if (saveContext.lastSaveDateTime.HasValue && saveContext.lastSaveDateTime < oldestDateTime)
                {
                    oldestSave = saveContext.saveFile;
                    oldestDateTime = saveContext.lastSaveDateTime.Value;
                }
            }

            return oldestSave;
        }

        /// <summary>
        /// Gets the save profile for the next available unused profile.
        /// </summary>
        /// <returns>An unused save profile, or null if no unused profile is available.</returns>
        public GameSave GetNextUnusedSave()
        {
            if (context == null) {
                Initialize();
            }

            for (int i = 0; i < context.Length; i++)
            {
                if (!context[i].exists) {
                    return context[i].saveFile;
                }
            }

            return null;
        }

        /// <summary>
        /// Checks if an unused save profile is available.
        /// </summary>
        /// <returns>True if an unused save profile is available, false otherwise.</returns>
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
