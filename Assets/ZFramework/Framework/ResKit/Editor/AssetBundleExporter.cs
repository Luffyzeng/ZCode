
using UnityEngine;
using System.IO;
using UnityEditor;

namespace ZFramework
{
    public class AssetBundleExporter : MonoBehaviour
    {
#if UNITY_EDITOR
        [MenuItem("ZFramework/Framework/ResKit/Build AssetBundles", false)]
        static void BuildAssetBundles()
        {
            var outputPath = Application.streamingAssetsPath + "/AssetBundles/" + ResKitUtil.GetPlatformName();

            if(!Directory.Exists(outputPath))
            {
                Directory.CreateDirectory(outputPath);
            }

            BuildPipeline.BuildAssetBundles(outputPath, BuildAssetBundleOptions.ChunkBasedCompression, EditorUserBuildSettings.activeBuildTarget);

            AssetDatabase.Refresh();
        }
#endif
    }
}