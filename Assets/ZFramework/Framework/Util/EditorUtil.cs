
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace ZFramework
{
    public partial class EditorUtil
    {
#if UNITY_EDITOR
        public static void ExportPackage(string assetPathName, string fileName)
        {
            AssetDatabase.ExportPackage(assetPathName, fileName, ExportPackageOptions.Recurse);
        }

        public static void CallMenuItem(string menuItemPath)
        {
            EditorApplication.ExecuteMenuItem(menuItemPath);
        }
#endif

    }
}