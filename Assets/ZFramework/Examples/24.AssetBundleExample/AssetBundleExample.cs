using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace ZCode
{
    public class AssetBundleExample : MonoBehaviour
    {
#if UNITY_EDITOR
        [UnityEditor.MenuItem("ZFramework/Examples/24.AssetBundleExample/Build AssetBundle", false, 24)]
        static void MenuClicked1()
        {
            if(!Directory.Exists(Application.streamingAssetsPath))
            {
                Directory.CreateDirectory(Application.streamingAssetsPath);
            }

            UnityEditor.BuildPipeline.BuildAssetBundles(Application.streamingAssetsPath, UnityEditor.BuildAssetBundleOptions.None, 
                UnityEditor.BuildTarget.StandaloneWindows);

        }

        [UnityEditor.MenuItem("ZFramework/Examples/24.AssetBundleExample/Run", false, 24)]
        static void MenuClicked2()
        {
            UnityEditor.EditorApplication.isPlaying = true;
            new GameObject("AssetBundleExample").AddComponent<AssetBundleExample>();
        }

#endif

        ResLoader mResLoader = new ResLoader();
        private AssetBundle mBundle;

        // Use this for initialization
        void Start()
        {
            mBundle = mResLoader.LoadSync<AssetBundle>("gameobject");

            var gameObj = mBundle.LoadAsset<GameObject>("GameObject");

            Instantiate(gameObj);
        }

        // Update is called once per frame
        void OnDestroy()
        {
            mResLoader.ReleaseAll();
        }
    }
}