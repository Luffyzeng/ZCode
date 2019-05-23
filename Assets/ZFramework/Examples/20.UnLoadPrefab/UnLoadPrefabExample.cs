using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZFramework
{
    public class UnLoadPrefabExample : MonoBehaviour
    {
#if UNITY_EDITOR
        [UnityEditor.MenuItem("ZFramework/Examples/20.UnLoadPrefab", false, 20)]
        static void MenuClicked()
        {
            UnityEditor.EditorApplication.isPlaying = true;
            new GameObject("UnLoadPrefabExample").AddComponent<UnLoadPrefabExample>();
        }

#endif
        // Use this for initialization
        IEnumerator Start()
        {
            var homePanelPrefab = Resources.Load<GameObject>("HomePanel");

            yield return new WaitForSeconds(3f);

            //UnloadAsset may only be used on individual assets and can not be used on GameObject's / Components or AssetBundles
            //Resources.UnloadAsset(homePanel);

            homePanelPrefab = null;
            Resources.UnloadUnusedAssets();
            Debug.Log("Unloaded");
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}