using System;
using System.IO;
using System.Text;
using UnityEngine;

namespace Zigurous.Architecture
{
    public abstract class GameSave<T> : ScriptableObject
        where T : GameSaveData, new()
    {
        public enum SaveFormat
        {
            PlainText,
            Base64,
        }

        private static readonly Encoding Encoding = Encoding.UTF8;

        [SerializeField] private string m_SaveName = "save1";
        [SerializeField] private string m_FileExtension = ".dat";
        [SerializeField] private SaveFormat m_DataFormat = SaveFormat.Base64;

        private string SavePath => Path.Combine(Application.persistentDataPath, $"{m_SaveName}{m_FileExtension}");

        private T m_Data;
        public T data => m_Data;

        public bool New()
        {
            Debug.Log($"Creating new save file: {SavePath}");
            m_Data = new();
            return Save();
        }

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

        private static string Serialize(T data, SaveFormat format)
        {
            string json = data.ToJson();

            return format switch {
                SaveFormat.PlainText => json,
                SaveFormat.Base64 => Convert.ToBase64String(Encoding.GetBytes(json)),
                _ => json,
            };
        }

        private static T Deserialize(string data, SaveFormat format)
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
