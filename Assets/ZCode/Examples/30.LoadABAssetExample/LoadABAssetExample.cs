using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZCode
{
    public class LoadABAssetExample : MonoBehaviour
    {
#if UNITY_EDITOR
        [UnityEditor.MenuItem("ZCode/Examples/30.LoadABAssetExample", false, 30)]
        static void MenuClicked()
        {
            UnityEditor.EditorApplication.isPlaying = true;
            new GameObject("LoadABAssetExample").AddComponent<LoadABAssetExample>();
        }
#endif

        ResLoader mResLoader = new ResLoader();
        // Use this for initialization
        void Start()
        {
            var squareTexture = mResLoader.LoadSync<Texture2D>("square", "Square");

            Debug.Log(squareTexture.name);

            //mResLoader.LoadAsync<GameObject>("gameobject", "GameObject", gameObjPrefab =>
            //{
            //    Instantiate(gameObjPrefab);
            //});
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}