
using UnityEngine;

namespace ZFramework
{
    public class TransformExtensionExample
    {
#if UNITY_EDITOR
        [UnityEditor.MenuItem("ZFramework/Examples/3.Transform API简化", false, 3)]
        private static void MenuClicked()
        {
            var transform = new GameObject("Transform").transform;
            transform.SetLocalPosX(5f);
            transform.SetLocalPosY(5f);
            transform.SetLocalPosZ(5f);
            transform.Identity();

        }
#endif

    }
}