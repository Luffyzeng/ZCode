using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZCode
{
    public partial class MathUtil
    {
        /// <summary>
        /// 从若干个值中随机取出一个值
        /// </summary>
        public static T GetRandomValueFrom<T>(params T[] values)
        {
            return values[Random.Range(0, values.Length)];
        }

    }
}