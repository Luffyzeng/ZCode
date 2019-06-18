using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QCode
{
    public class MonoSingletonExample : MonoSingleton<MonoSingletonExample>
    {
#if UNITY_EDITOR
        [UnityEditor.MenuItem("QCode/Examples/14.MonoSingleton", false, 14)]
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