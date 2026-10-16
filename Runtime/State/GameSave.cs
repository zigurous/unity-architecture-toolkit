using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A serializable representation of a game save file.
    /// </summary>
    public abstract class GameSave : ScriptableObject
    {
        /// <summary>
        /// A data/encoding format for a game save file.
        /// </summary>
        public enum SaveFormat
        {
            /// <summary>
            /// The save file is written in plain text, UTF-8 encoding.
            /// </summary>
            [Tooltip("The save file is written in plain text, UTF-8 encoding.")]
            PlainText,

            /// <summary>
            /// The save file is written in base64 encoding.
            /// </summary>
            [Tooltip("The save file is written in base64 encoding.")]
            Base64,
        }

        private static readonly Encoding Encoding = Encoding.UTF8;

        [NonSerialized]
        [Tooltip("The deserialized save data.")]
        protected GameSaveData m_Data;

        [SerializeField]
        [Tooltip("The name of the save file, without any file extensions.")]
        protected string m_SaveName = "save1";

        [SerializeField]
        [Tooltip("The file extension of the save file.")]
        protected string m_FileExtension = ".dat";

        [SerializeField]
        [Tooltip("The format of the data written to the save file.")]
        protected SaveFormat m_DataFormat = SaveFormat.Base64;

        [SerializeField]
        [Tooltip("Resets the save data when loaded as if it were a new save file.")]
        protected bool m_ResetDataOnLoad;

        #if UNITY_EDITOR || DEVELOPMENT_BUILD
        [SerializeField]
        [Tooltip("Loads custom data instead of reading from the save file. This useful for development purposes and scenario testing.")]
        protected bool m_LoadCustomData;
        #endif

        /// <summary>
        /// The name of the save file, without any file extensions.
        /// </summary>
        public string SaveName => m_SaveName;

        /// <summary>
        /// The full path to the save file.
        /// </summary>
        public string SavePath => Path.Combine(Application.persistentDataPath, $"{m_SaveName}{m_FileExtension}");

        /// <summary>
        /// The file extension of the save file.
        /// </summary>
        public string FileExtension => m_FileExtension;

        /// <summary>
        /// The format of the data written to the save file.
        /// </summary>
        public SaveFormat DataFormat => m_DataFormat;

        /// <summary>
        /// Whether the save data has been loaded into memory.
        /// </summary>
        public bool IsLoaded => m_Data != null;

        /// <summary>
        /// The type of data to deserialize.
        /// </summary>
        protected abstract Type DataType { get; }

        /// <summary>
        /// Creates a new save data object.
        /// </summary>
        /// <returns>The new save data.</returns>
        protected abstract GameSaveData GetNewData();

        #if UNITY_EDITOR || DEVELOPMENT_BUILD
        /// <summary>
        /// Gets the custom data to read instead of reading from the save file.
        /// </summary>
        /// <returns>The custom data.</returns>
        protected abstract GameSaveData GetCustomData();
        #endif

        /// <summary>
        /// Creates a new save file. If the save file already exists, then it
        /// will be overwritten with default data.
        /// </summary>
        public IEnumerator New()
        {
            yield return WaitForAsyncTask(NewAsync());
        }

        /// <summary>
        /// Creates a new save file asynchronously. If the save file already
        /// exists, then it will be overwritten with default data.
        /// </summary>
        public async Task NewAsync()
        {
            #if UNITY_EDITOR || DEVELOPMENT_BUILD
            if (m_LoadCustomData)
            {
                m_Data = GetCustomData();
                await SaveAsync();
                return;
            }
            #endif

            Debug.Log($"Creating new save file: {SavePath}");
            m_Data = GetNewData();
            await SaveAsync();
        }

        /// <summary>
        /// Loads the data from the save file.
        /// </summary>
        public IEnumerator Load()
        {
            yield return WaitForAsyncTask(LoadAsync());
        }

        /// <summary>
        /// Loads the data from the save file asynchronously.
        /// </summary>
        public async Task LoadAsync()
        {
            #if UNITY_EDITOR || DEVELOPMENT_BUILD
            if (m_LoadCustomData)
            {
                m_Data = GetCustomData();
                return;
            }
            #endif

            if (m_ResetDataOnLoad || !Exists())
            {
                await NewAsync();
                return;
            }

            try
            {
                string filePath = SavePath;
                Debug.Log($"Loading save file: {filePath}");
                string contents = await File.ReadAllTextAsync(filePath);
                m_Data = Deserialize(contents, DataType, DataFormat);
            }
            catch (Exception e)
            {
                m_Data = GetNewData();
                Debug.LogError($"An error occured trying to load data from file: {SavePath}\n{e}");
            }
        }

        /// <summary>
        /// Writes the data to the save file.
        /// </summary>
        public IEnumerator Save()
        {
            yield return WaitForAsyncTask(SaveAsync());
        }

        /// <summary>
        /// Writes the data to the save file asynchronously.
        /// </summary>
        public async Task SaveAsync()
        {
            try
            {
                string filePath = SavePath;
                string contents = Serialize(m_Data, m_DataFormat);
                Debug.Log($"Saving game state: {filePath}");
                await File.WriteAllTextAsync(filePath, contents, Encoding);
            }
            catch (Exception e)
            {
                Debug.LogError($"An error occurred trying to save data to file: {SavePath}\n{e}");
            }
        }

        /// <summary>
        /// Deletes the save file.
        /// </summary>
        /// <returns>True if the save file was deleted without errors, false otherwise.</returns>
        public bool Delete()
        {
            try
            {
                string filePath = SavePath;
                Debug.Log($"Deleting save file: {filePath}");
                File.Delete(filePath);
                m_Data = null;
                return true;
            }
            catch (Exception e)
            {
                Debug.LogError($"An error occurred trying to delete save file: {SavePath}\n{e}");
                return false;
            }
        }

        /// <summary>
        /// Checks if the save file exists.
        /// </summary>
        /// <returns>True if the save file exists, false otherwise.</returns>
        public bool Exists()
        {
            try {
                return File.Exists(SavePath);
            } catch {
                return false;
            }
        }

        /// <summary>
        /// Gets the last date/time the save file was written.
        /// </summary>
        /// <returns>The last date/time the save file was written or null if the
        /// file does not exist.</returns>
        public DateTime? GetLastWriteTime()
        {
            try {
                return File.GetLastWriteTime(SavePath);
            } catch {
                return null;
            }
        }

        private IEnumerator WaitForAsyncTask(Task task)
        {
            while (!task.IsCompleted) {
                yield return null;
            }

            if (task.IsFaulted && task.Exception != null) {
                throw task.Exception.InnerException ?? task.Exception;
            }

            if (task.IsCanceled) {
                yield break;
            }
        }

        /// <summary>
        /// Serializes the save data to the given format.
        /// </summary>
        /// <param name="data">The data object to serialize.</param>
        /// <param name="format">The format to serialize the data to.</param>
        /// <returns>The serialized data as a string.</returns>
        public static string Serialize(GameSaveData data, SaveFormat format)
        {
            string json = data.ToJson();

            return format switch {
                SaveFormat.PlainText => json,
                SaveFormat.Base64 => Convert.ToBase64String(Encoding.GetBytes(json)),
                _ => json,
            };
        }

        /// <summary>
        /// Deserializes the save data from the given format.
        /// </summary>
        /// <typeparam name="T">The type of save data.</typeparam>
        /// <param name="data">The string of data to deserialize.</param>
        /// <param name="format">The format of the data as written to the save file.</param>
        /// <returns>The deserialized save data.</returns>
        public static T Deserialize<T>(string data, SaveFormat format) where T : GameSaveData
        {
            string json = format switch {
                SaveFormat.PlainText => data,
                SaveFormat.Base64 => Encoding.GetString(Convert.FromBase64String(data)),
                _ => data,
            };

            return JsonUtility.FromJson<T>(json);
        }

        /// <summary>
        /// Deserializes the save data from the given format.
        /// </summary>
        /// <param name="data">The string of data to deserialize.</param>
        /// <param name="dataType">The type of save data to deserialize to.</param>
        /// <param name="format">The format of the data as written to the save file.</param>
        /// <returns>The deserialized save data.</returns>
        public static GameSaveData Deserialize(string data, Type dataType, SaveFormat format)
        {
            string json = format switch {
                SaveFormat.PlainText => data,
                SaveFormat.Base64 => Encoding.GetString(Convert.FromBase64String(data)),
                _ => data,
            };

            return JsonUtility.FromJson(json, dataType) as GameSaveData;
        }

    }

    /// <summary>
    /// A serializable representation of a game save file.
    /// </summary>
    /// <typeparam name="T">The type of save data.</typeparam>
    public abstract class GameSave<T> : GameSave
        where T : GameSaveData, new()
    {
        #if UNITY_EDITOR || DEVELOPMENT_BUILD
        [SerializeField]
        [ConditionalShow(nameof(m_LoadCustomData))]
        [Tooltip("The custom data to load.")]
        private T m_CustomData;
        #endif

        /// <summary>
        /// The deserialized save data.
        /// </summary>
        public T data => m_Data as T;

        /// <inheritdoc/>
        protected override Type DataType => typeof(T);

        /// <inheritdoc/>
        protected override GameSaveData GetNewData()
        {
            return new T();
        }

        #if UNITY_EDITOR || DEVELOPMENT_BUILD
        /// <inheritdoc/>
        protected override GameSaveData GetCustomData()
        {
            return m_CustomData;
        }
        #endif

        /// <summary>
        /// Creates a new save file. If the save file already exists, then it
        /// will be overwritten with default data.
        /// </summary>
        /// <param name="onComplete">An action invoked after the save file has been created.</param>
        public IEnumerator New(Action<GameSave<T>> onComplete)
        {
            yield return New();
            onComplete?.Invoke(this);
        }

        /// <summary>
        /// Loads the data from the save file.
        /// </summary>
        /// <param name="onComplete">An action invoked after the save file has been loaded.</param>
        public IEnumerator Load(Action<GameSave<T>> onComplete)
        {
            yield return Load();
            onComplete?.Invoke(this);
        }

        /// <summary>
        /// Writes the data to the save file.
        /// </summary>
        /// <param name="onComplete">An action invoked after the save file has been updated.</param>
        public IEnumerator Save(Action<GameSave<T>> onComplete)
        {
            yield return Save();
            onComplete?.Invoke(this);
        }

    }

}
