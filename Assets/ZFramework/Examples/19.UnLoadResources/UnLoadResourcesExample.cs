using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZFramework
{
    public class UnLoadResourcesExample : MonoBehaviour
    {
#if UNITY_EDITOR
        [UnityEditor.MenuItem("ZFramework/Examples/19.UnLoadResources", false, 19)]
        static void MenuClicked()
        {
            UnityEditor.EditorApplication.isPlaying = true;
            new GameObject("UnLoadResourcesExample").AddComponent<UnLoadResourcesExample>();
        }

#endif
        // Use this for initialization
        IEnumerator Start()
        {
            var hit = Resources.Load<AudioClip>("hit");
            yield return new WaitForSeconds(3f);
            Resources.UnloadAsset(hit);
            Debug.Log("UnLoaded");
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}