using UnityEditor;
using UnityEngine;

namespace Zigurous.Architecture.Editor
{
    public static class HideFlagsUtility
    {
        [MenuItem("Help/Show Hidden Objects")]
        private static void ShowAll()
        {
            var gameObjects = Object.FindObjectsOfType<GameObject>();

            foreach (var go in gameObjects)
            {
                switch (go.hideFlags)
                {
                    case HideFlags.HideAndDontSave:
                        go.hideFlags = HideFlags.DontSave;
                        break;

                    case HideFlags.HideInHierarchy:
                    case HideFlags.HideInInspector:
                    case HideFlags.HideInHierarchy | HideFlags.HideInInspector:
                        go.hideFlags = HideFlags.None;
                        break;
                }
            }
        }

    }

}
