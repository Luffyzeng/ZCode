using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QCode
{
    public class PoolManagerExample : MonoBehaviour
    {
#if UNITY_EDITOR
        [UnityEditor.MenuItem("QCode/Examples/11.PoolManager", false, 11)]
        static void MenuClicked()
        {
            var fishPool = new SimpleObjectPool<Fish>(() => new Fish(), null, 100);
            Debug.LogFormat("fishPool.Count:{0}", fishPool.CurCount);
            var fishOne = fishPool.Allocate();
            Debug.LogFormat("fishPool.Count:{0}", fishPool.CurCount);
            fishPool.Recycle(fishOne);
            Debug.LogFormat("fishPool.Count:{0}", fishPool.CurCount);
            for (int i = 0; i < 10; i++)
            {
                fishPool.Allocate();
            }
            Debug.LogFormat("fishPool.Count:{0}", fishPool.CurCount);
        }
#endif
        
        private class Fish
        {

        }

    }
}