using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZCode
{
    public class MathUtilExample
    {
#if UNITY_EDITOR
        [UnityEditor.MenuItem("ZCode/Examples/4.随机函数", false, 4)]
#endif
        private static void MenuClicked()
        {
            Debug.Log(MathUtil.GetRandomValueFrom<int>(1, 2, 3, 4));
            Debug.Log(MathUtil.GetRandomValueFrom<string>("A","B"));
            Debug.Log(MathUtil.GetRandomValueFrom<float>(1.2f,2.2f,3.3f));
        }

    }
}