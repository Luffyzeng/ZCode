using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ZFramework
{
    public class ResData : Singleton<ResData>
    {
        private ResData()
        {
            Load();
        }

        public List<AssetBundleData> AssetBundleDatas = new List<AssetBundleData>();

        private static AssetBundleManifest mManifest;

        public void Load()
        {
            if (ResMgr.IsSimulationModeLogic)
            {
#if UNITY_EDITOR

                var assetBundleNames = UnityEditor.AssetDatabase.GetAllAssetBundleNames();

                foreach (var assetBundleName in assetBundleNames)
                {
                    var dependencyBundleNames = UnityEditor.AssetDatabase.GetAssetBundleDependencies(assetBundleName, false);

                    var assetBundleData = new AssetBundleData { Name = assetBundleName, dependencyBundleNames = dependencyBundleNames };

                    var assetPaths = UnityEditor.AssetDatabase.GetAssetPathsFromAssetBundle(assetBundleName);

                    foreach (var assetPath in assetPaths)
                    {
                        var assetData = new AssetData()
                        {
                            Name = assetPath.Split('/').Last().Split('.').First(),
                            OwnerBundleName = assetBundleName
                        };

                        assetBundleData.AssetDataList.Add(assetData);
                    }

                    AssetBundleDatas.Add(assetBundleData);
                }
#endif
            }
            else
            {
                var maniBundle = AssetBundle.LoadFromFile(ResKitUtil.FullPathForAssetBundle(ResKitUtil.GetPlatformName()));
                mManifest = maniBundle.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
            }
        }

        public string[] GetDirectDependencies(string bundleName)
        {
            if (ResMgr.IsSimulationModeLogic)
            {
                return AssetBundleDatas.Find(abData => abData.Name == bundleName).dependencyBundleNames;

            }

            return mManifest.GetDirectDependencies(bundleName);
        }
    }
}