using System;
using System.IO;
using System.Text;
using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A serializable representation of a game save file.
    /// </summary>
    /// <typeparam name="T">The type of save data.</typeparam>
    public abstract class GameSave<T> : ScriptableObject
        where T : GameSaveData, new()
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

        [SerializeField]
        [Tooltip("The name of the save file, without any file extensions.")]
        private string m_SaveName = "save1";

        [SerializeField]
        [Tooltip("The file extension of the save file.")]
        private string m_FileExtension = ".dat";

        [SerializeField]
        [Tooltip("The format of the data written to the save file.")]
        private SaveFormat m_DataFormat = SaveFormat.Base64;

        [Tooltip("The deserialized save data.")]
        private T m_Data;

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
        /// The deserialized save data.
        /// </summary>
        public T data => m_Data;

        /// <summary>
        /// Creates a new save file. If the save file already exists, then it
        /// will be overwritten with default data.
        /// </summary>
        /// <returns>True if the save file was created without errors, false otherwise.</returns>
        public bool New()
        {
            Debug.Log($"Creating new save file: {SavePath}");
            m_Data = new();
            return Save();
        }

        /// <summary>
        /// Loads the data from the save file.
        /// </summary>
        /// <returns>True if the save file was loaded without errors, false otherwise.</returns>
        public bool Load()
        {
            if (!Exists()) {
                return New();
            }

            string filePath = SavePath;

            try
            {
                Debug.Log($"Loading save file: {filePath}");
                using FileStream stream = new(filePath, FileMode.OpenOrCreate);
                using BinaryReader reader = new(stream, Encoding);
                string data = reader.ReadString();
                m_Data = Deserialize(data, m_DataFormat);
                return true;
            }
            catch (Exception e)
            {
                m_Data = new();
                Debug.LogError($"An error occured trying to load data from file: {filePath}\n{e}");
                return false;
            }
        }

        /// <summary>
        /// Saves the data to the save file.
        /// </summary>
        /// <returns>True if the data was saved without errors, false otherwise.</returns>
        public bool Save()
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
        public bool Delete()
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
        public bool Exists()
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
        /// <param name="data">The data to serialize.</param>
        /// <param name="format">The format to serialize the data to.</param>
        /// <returns>The serialized data as a string.</returns>
        public static string Serialize(T data, SaveFormat format)
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
        /// <param name="data">The data to deserialize.</param>
        /// <param name="format">The format of the data as written to the save file.</param>
        /// <returns>The deserialized save data.</returns>
        public static T Deserialize(string data, SaveFormat format)
        {
            string json = format switch {
                SaveFormat.PlainText => data,
                SaveFormat.Base64 => Encoding.GetString(Convert.FromBase64String(data)),
                _ => data,
            };

            return JsonUtility.FromJson<T>(json);
        }

    }

}
