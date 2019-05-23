using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZCode
{
    public class DelayWithCoroutine : MonoBehaviourSimplify
    {
        // Use this for initialization
        void Start()
        {
            Delay(5f,()=>{
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#endif
            });
        }

#if UNITY_EDITOR
        [UnityEditor.MenuItem("ZFramework/Examples/5.定时功能",false,5)]
        static void MenuClicked()
        {
            UnityEditor.EditorApplication.isPlaying = true;
            new GameObject("DelayWithCoroutine").AddComponent<DelayWithCoroutine>();
        }
#endif

        protected override void OnBeforeDestory()
        {

        }

    }

}