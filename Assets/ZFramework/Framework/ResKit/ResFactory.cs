using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZFramework
{
    public class ResFactory 
    {
        public static Res CreateRes(string assetName, string assetBundleName = null)
        {
            Res res = null;

            if (assetBundleName != null)
            {
                res = new AssetRes(assetName, assetBundleName);
            }
            else if (assetName.StartsWith("resources://"))
            {
                res = new ResourcesRes(assetName);
            }
            else
            {
                res = new AssetBundleRes(assetName);
            }

            return res;
        }
    }
}