using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZCode
{
    public class GUIManagerExample : MonoBehaviourSimplify
    {
        protected override void OnBeforeDestory()
        {
        }

#if UNITY_EDITOR
        [UnityEditor.MenuItem("ZFramework/Examples/9.GUIManager", false, 9)]
        static void MenuClicked()
        {
            UnityEditor.EditorApplication.isPlaying = true;
            new GameObject("GUIManagerExample").AddComponent<GUIManagerExample>();
        }
#endif

        // Use this for initialization
        void Start()
        {
            GUIManager.LoadPanel("HomePanel",UILayer.Common);
            Delay(2.0f, () => { GUIManager.UnLoad("HomePanel"); });
        }

    }
}