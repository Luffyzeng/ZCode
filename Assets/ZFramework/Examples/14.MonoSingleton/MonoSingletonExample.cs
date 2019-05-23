using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZCode
{
    public class MonoSingletonExample : MonoSingleton<MonoSingletonExample>
    {
#if UNITY_EDITOR
        [UnityEditor.MenuItem("ZFramework/Examples/14.MonoSingleton", false, 14)]
        static void MenuClicked()
        {
            UnityEditor.EditorApplication.isPlaying = true;
        }

#endif
        //[RuntimeInitializeOnLoadMethod]
        //private static void Example()
        //{
        //    var initInstance = MonoSingletonExample.Instance;
        //    initInstance = MonoSingletonExample.Instance;
        //}
    }
}