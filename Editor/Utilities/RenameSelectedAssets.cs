using UnityEditor;
using UnityEngine;

namespace Zigurous.Architecture.Editor
{
    public sealed class RenameSelectedAssets : EditorWindow
    {
        private string find;
        private string replace;
        private string prefix;
        private string suffix;

        [MenuItem("Edit/Rename Selected Assets...")]
        public static void ShowWindow()
        {
            EditorWindow window = EditorWindow.GetWindow(typeof(RenameSelectedAssets), false, "Rename Selected Assets");
            window.minSize = new Vector2(300f, 150f);
        }

        private void OnGUI()
        {
            EditorGUILayout.Space(10f);

            find = EditorGUILayout.TextField("Find", find);
            replace = EditorGUILayout.TextField("Replace", replace);
            prefix = EditorGUILayout.TextField("Prefix", prefix);
            suffix = EditorGUILayout.TextField("Suffix", suffix);

            EditorGUILayout.Space(10f);
            EditorGUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();

            if (GUILayout.Button("Rename Selected Assets", GUILayout.Width(200f), GUILayout.Height(25f))) {
                Rename();
            }

            GUILayout.FlexibleSpace();
            EditorGUILayout.EndHorizontal();
        }

        private void Rename()
        {
            string[] assets = Selection.assetGUIDs;

            for (int i = 0; i < assets.Length; i++)
            {
                string path = AssetDatabase.GUIDToAssetPath(assets[i]);
                string name = System.IO.Path.GetFileNameWithoutExtension(path);

                if (find != null && find.Length > 0) {
                    name = name.Replace(find, replace);
                }

                name = prefix + name + suffix;
                AssetDatabase.RenameAsset(path, name);
            }

            AssetDatabase.Refresh();
        }

    }

}
