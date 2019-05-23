using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ZCode
{
    public class DisplayResLoadInfo : MonoBehaviour
    {
#if UNITY_EDITOR
        [UnityEditor.MenuItem("ZCode/Examples/23.DisplayResLoadInfo", false, 23)]
        static void MenuClicked()
        {
            UnityEditor.EditorApplication.isPlaying = true;
            new GameObject("DisplayResLoadInfo").AddComponent<DisplayResLoadInfo>();
        }

#endif

        ResLoader mResLoader = new ResLoader();

        // Use this for initialization
        IEnumerator Start()
        {
            yield return new WaitForSeconds(2f);

            mResLoader.LoadAsync<AudioClip>("resources://hit", hitClip=> {
                Debug.Log(hitClip.name);
                Debug.Log(Time.deltaTime);
            });

            Debug.Log(Time.deltaTime);

            mResLoader.LoadSync<GameObject>("resources://HomePanel");

            yield return new WaitForSeconds(2f);

            mResLoader.LoadSync<AudioClip>("resources://bgm");

            mResLoader.LoadSync<AudioClip>("resources://Audio/hit");

            yield return new WaitForSeconds(5f);

            mResLoader.ReleaseAll();
        }



        // Update is called once per frame
        void Update()
        {

        }
    }
}