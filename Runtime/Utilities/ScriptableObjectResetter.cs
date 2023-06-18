using UnityEditor;
using UnityEngine;

namespace Zigurous.Architecture
{
    #if UNITY_EDITOR
    /// <summary>
    /// Resets scriptable objects back to their original values upon exiting
    /// play mode (editor only).
    /// </summary>
    public static class ScriptableObjectResetter
    {
        [InitializeOnLoadMethod]
        private static void RegisterResets()
        {
            EditorApplication.playModeStateChanged -= ResetAssets;
            EditorApplication.playModeStateChanged += ResetAssets;
        }

        private static void ResetAssets(PlayModeStateChange change)
        {
            if (change == PlayModeStateChange.ExitingPlayMode)
            {
                ScriptableObject[] assets = FindAssets<ScriptableObject>();

                foreach (ScriptableObject asset in assets)
                {
                    if (asset is IScriptableObjectResettable resettable) {
                        resettable.ResetValues();
                    }
                }
            }
        }

        private static T[] FindAssets<T>() where T : Object
        {
            string[] guids = AssetDatabase.FindAssets($"t:{typeof(T)}");
            T[] assets = new T[guids.Length];

            for (int i = 0; i < guids.Length; i++)
            {
                string path = AssetDatabase.GUIDToAssetPath(guids[i]);
                assets[i] = AssetDatabase.LoadAssetAtPath<T>(path);
            }

            return assets;
        }

    }
    #endif

    /// <summary>
    /// A type of ScriptableObject that can reset its values.
    /// </summary>
    public interface IScriptableObjectResettable
    {
        /// <summary>
        /// Resets the values of the ScriptableObject.
        /// </summary>
        void ResetValues();
    }

}
