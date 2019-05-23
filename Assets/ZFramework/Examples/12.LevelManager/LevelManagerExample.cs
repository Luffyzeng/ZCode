using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZCode
{
    public class LevelManagerExample : MonoBehaviourSimplify
    {
#if UNITY_EDITOR
        [UnityEditor.MenuItem("ZFramework/Examples/12.LevelManager", false, 12)]
        static void MenuClicked()
        {
            UnityEditor.EditorApplication.isPlaying = true;
            new GameObject("LevelManagerExample").AddComponent<LevelManagerExample>();
        }

#endif
        // Use this for initialization
        void Start()
        {
            DontDestroyOnLoad(this);
            LevelManager.Init(new List<string>
            {
                "Level0",
                "Level1"
            });

            LevelManager.LoadCurrent();
            Delay(10f, LevelManager.LoadNext);
        }


        protected override void OnBeforeDestory()
        {
        }
    }
}