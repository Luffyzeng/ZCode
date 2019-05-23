using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ZFramework
{
    public class NewBehaviourScript : MonoBehaviour
    {
#if UNITY_EDITOR
        [UnityEditor.MenuItem("ZFramework/Playground",false)]
        static void MenuClick()
        {
            var resData = ResData.Instance;

            resData.AssetBundleDatas.Clear();

            var assetBundleNames = UnityEditor.AssetDatabase.GetAllAssetBundleNames();

            foreach (var assetBundleName in assetBundleNames)
            {
                var dependencyBundleNames = UnityEditor.AssetDatabase.GetAssetBundleDependencies(assetBundleName, false);

                var assetBundleData = new AssetBundleData { Name = assetBundleName, dependencyBundleNames=dependencyBundleNames};

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

                ResData.Instance.AssetBundleDatas.Add(assetBundleData);
            }

            //log
            resData.AssetBundleDatas.ForEach(abData =>
            {
                abData.AssetDataList.ForEach(assetData =>
                {
                    Debug.LogFormat(" AB: {0} Asset: {1} ", abData.Name, assetData.Name);
                });

                foreach (var dependencyBundleName in abData.dependencyBundleNames)
                {
                    Debug.LogFormat(" {0} depend on {1} ", abData.Name, dependencyBundleName);
                }
            });
        }
#endif
    }
} 