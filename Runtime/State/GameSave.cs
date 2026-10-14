using System;
using System.IO;
using System.Text;
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

        [Tooltip("The deserialized save data.")]
        protected GameSaveData m_Data;

        [SerializeField]
        [Tooltip("The name of the save file, without any file extensions.")]
        private string m_SaveName = "save1";

        [SerializeField]
        [Tooltip("The file extension of the save file.")]
        private string m_FileExtension = ".dat";

        [SerializeField]
        [Tooltip("The format of the data written to the save file.")]
        private SaveFormat m_DataFormat = SaveFormat.Base64;

        [SerializeField]
        [Tooltip("Resets the save data when loaded as if it were a new save file.")]
        private bool m_ResetDataOnLoad;

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
        /// The type of data to deserialize.
        /// </summary>
        protected abstract Type DataType { get; }

        /// <summary>
        /// Creates a new save data object.
        /// </summary>
        /// <returns>The new data object.</returns>
        protected abstract GameSaveData NewDataObject();

        /// <summary>
        /// Creates a new save file. If the save file already exists, then it
        /// will be overwritten with default data.
        /// </summary>
        /// <returns>True if the save file was created without errors, false otherwise.</returns>
        public virtual bool New()
        {
            Debug.Log($"Creating new save file: {SavePath}");
            m_Data = NewDataObject();
            return Save();
        }

        /// <summary>
        /// Loads the data from the save file.
        /// </summary>
        /// <returns>True if the save file was loaded without errors, false otherwise.</returns>
        public virtual bool Load()
        {
            if (m_ResetDataOnLoad || !Exists()) {
                return New();
            }

            string filePath = SavePath;

            try
            {
                Debug.Log($"Loading save file: {filePath}");
                using FileStream stream = new(filePath, FileMode.OpenOrCreate);
                using BinaryReader reader = new(stream, Encoding);
                string data = reader.ReadString();
                m_Data = Deserialize(data, DataType, m_DataFormat);
                return m_Data != null;
            }
            catch (Exception e)
            {
                m_Data = NewDataObject();
                Debug.LogError($"An error occured trying to load data from file: {filePath}\n{e}");
                return false;
            }
        }

        /// <summary>
        /// Saves the data to the save file.
        /// </summary>
        /// <returns>True if the data was saved without errors, false otherwise.</returns>
        public virtual bool Save()
        {
            string filePath = SavePath;

            try
            {
                Debug.Log($"Saving game state: {filePath}");
                using FileStream stream = new(filePath, FileMode.Create);
                using BinaryWriter writer = new(stream, Encoding);
                writer.Write(Serialize(m_Data, m_DataFormat));
                return true;
            }
            catch (Exception e)
            {
                Debug.LogError($"An error occurred trying to save data to file: {filePath}\n{e}");
                return false;
            }
        }

        /// <summary>
        /// Deletes the save file.
        /// </summary>
        /// <returns>True if the save file was deleted without errors, false otherwise.</returns>
        public virtual bool Delete()
        {
            string filePath = SavePath;

            try
            {
                File.Delete(filePath);
                return true;
            }
            catch (Exception e)
            {
                Debug.LogError($"An error occurred trying to delete save file: {filePath}\n{e}");
                return false;
            }
        }

        /// <summary>
        /// Checks if the save file exists.
        /// </summary>
        /// <returns>True if the save file exists, false otherwise.</returns>
        public virtual bool Exists()
        {
            try
            {
                using FileStream stream = new(SavePath, FileMode.Open);
                using BinaryReader reader = new(stream, Encoding);
                string data = reader.ReadString();
                return !string.IsNullOrEmpty(data.Trim());
            }
            catch
            {
                return false;
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
        [Tooltip("Loads custom data instead of reading from the save file. This useful for development purposes and scenario testing.")]
        private bool m_LoadCustomData;

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
        protected override GameSaveData NewDataObject()
        {
            return new T();
        }

        /// <inheritdoc/>
        public override bool New()
        {
            #if UNITY_EDITOR || DEVELOPMENT_BUILD
            if (m_LoadCustomData)
            {
                m_Data = m_CustomData;
                return Save();
            }
            #endif

            return base.New();
        }

        /// <inheritdoc/>
        public override bool Load()
        {
            #if UNITY_EDITOR || DEVELOPMENT_BUILD
            if (m_LoadCustomData)
            {
                m_Data = m_CustomData;
                return true;
            }
            #endif

            return base.Load();
        }

    }

}
