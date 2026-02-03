using UnityEditor;
using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A ScriptableObject with a serialized GUID property.
    /// </summary>
    [CreateAssetMenu(menuName = "Zigurous/Utils/ScriptableObjectWithGUID")]
    [HelpURL("https://docs.zigurous.com/com.zigurous.architecture/api/Zigurous.Architecture/ScriptableObjectWithGUID")]
    public class ScriptableObjectWithGUID : ScriptableObject
    {
        [ReadOnly]
        [SerializeField]
        [Tooltip("The unique GUID of the object.")]
        private int m_GUID = default;

        /// <summary>
        /// The unique guid of the object.
        /// </summary>
        public int guid => m_GUID;

        #if UNITY_EDITOR
        protected virtual void OnValidate()
        {
            if (m_GUID == default) {
                SetGUID();
            }
        }

        private void SetGUID()
        {
            if (AssetDatabase.TryGetGUIDAndLocalFileIdentifier(this, out string guid, out _)) {
                m_GUID = guid.GetHashCode();
            } else {
                m_GUID = GetInstanceID();
            }

            EditorUtility.SetDirty(this);
        }

        [MenuItem("CONTEXT/ScriptableObjectWithGUID/Save GUID")]
        private static void SaveGUID()
        {
            Object[] selection = Selection.objects;

            if (selection != null)
            {
                for (int i = 0; i < selection.Length; i++)
                {
                    if (selection[i] is ScriptableObjectWithGUID obj)
                    {
                        obj.OnValidate();
                        EditorUtility.SetDirty(obj);
                    }
                }

                AssetDatabase.SaveAssets();
            }
        }

        [MenuItem("CONTEXT/ScriptableObjectWithGUID/Regenerate GUID")]
        private static void RegenerateGUID()
        {
            Object[] selection = Selection.objects;

            if (selection != null)
            {
                for (int i = 0; i < selection.Length; i++)
                {
                    if (selection[i] is ScriptableObjectWithGUID obj) {
                        obj.SetGUID();
                    }
                }

                AssetDatabase.SaveAssets();
            }
        }
        #endif

    }

}
