using UnityEditor;
using UnityEngine;

namespace Zigurous.Architecture.Editor
{
    public static class HideFlagsUtility
    {
        [MenuItem("Help/Show Hidden Objects")]
        private static void ShowAll()
        {
            GameObject[] objs = Object.FindObjectsByType<GameObject>(FindObjectsSortMode.None);

            foreach (GameObject go in objs)
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
