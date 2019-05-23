using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZCode
{
    public class UIXXXPanel : MonoBehaviour
    {
#if UNITY_EDITOR
        [UnityEditor.MenuItem("ZFramework/Examples/21.ResMgrExample", false, 21)]
        static void MenuClicked()
        {
            UnityEditor.EditorApplication.isPlaying = true;
            new GameObject("UIXXXPanel").AddComponent<UIXXXPanel>()
                .gameObject.AddComponent<UIYYYPanel>();
        }

#endif

        ResLoader mResLoader = new ResLoader();
        
        // Use this for initialization
        void Start()
        {
            var hitClip =mResLoader. LoadSync<AudioClip>("resources://hit");

            var coinClip = mResLoader.LoadSync<AudioClip>("resources://hit");

            var bgmClip = mResLoader.LoadSync<AudioClip>("resources://bgm");
        }


        void OnDestroy()
        {
            Debug.Log("UIXXXPanel");
            mResLoader.ReleaseAll();
        }
    }

    public class UIYYYPanel : MonoBehaviour
    {
        ResLoader mResLoader = new ResLoader();

        // Use this for initialization
        void Start()
        {
            var hitClip = mResLoader.LoadSync<AudioClip>("resources://hit");

            var coinClip = mResLoader.LoadSync<AudioClip>("resources://hit");

            var bgmClip = mResLoader.LoadSync<AudioClip>("resources://bgm");
        }


        void OnDestroy()
        {
            Debug.Log("UIYYYPanel");
            mResLoader.ReleaseAll();
        }
    }
}