using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZCode
{
    public class LoadDependencyAsyncExample : MonoBehaviour
    {
#if UNITY_EDITOR
        [UnityEditor.MenuItem("ZFramework/Examples/29.LoadDependencyAsyncExample", false, 29)]
        static void MenuClicked()
        {
            UnityEditor.EditorApplication.isPlaying = true;
            new GameObject("LoadDependencyAsyncExample").AddComponent<LoadDependencyAsyncExample>();
        }
#endif

        ResLoader mResLoader = new ResLoader();

        // Use this for initialization
        void Start()
        {
            mResLoader.LoadAsync<AssetBundle>("gameobject", loadedBundle =>
            {
                var gameObj = loadedBundle.LoadAsset<GameObject>("gameobject");

                Instantiate(gameObj);
            });
        }

        // Update is called once per frame
        void OnDestroy()
        {
            mResLoader.ReleaseAll();
            mResLoader = null;
        }
    }
}