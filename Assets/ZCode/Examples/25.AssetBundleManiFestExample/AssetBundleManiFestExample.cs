using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ZCode
{
    public class AssetBundleManiFestExample : MonoBehaviour
    {

#if UNITY_EDITOR
        [UnityEditor.MenuItem("ZCode/Examples/25.AssetBundleManiFestExample", false, 25)]
        static void MenuClicked()
        {

            var maniAssetBundle = AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/StreamingAssets");

            var bundleManifest = maniAssetBundle.LoadAsset<AssetBundleManifest>("AssetBundleManifest");

            bundleManifest.GetAllDependencies("gameobject")
                .ToList()
                .ForEach(dependency =>
                {
                    Debug.LogFormat("gameobject dependency:{0}", dependency);
                });

            bundleManifest.GetAllAssetBundles()
                .ToList()
                .ForEach(assetBundle =>
                {
                    Debug.Log(assetBundle);
                });

            bundleManifest.GetDirectDependencies("gameobject")
                .ToList()
                .ForEach(dependency =>
                {
                    Debug.LogFormat("gameobject dependency:{0}", dependency);
                });

            maniAssetBundle.Unload(true);
        }

#endif
    }
}