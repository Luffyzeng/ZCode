using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZCode
{
    public class ResourcesRes : Res
    {
        private string mPath;

        public ResourcesRes(string assetPath)
        {
            mPath = assetPath.Substring("resources://".Length);

            Name = assetPath;

            State = ResState.Waiting;
        }

        public override bool LoadSync()
        {
            State = ResState.Loading;

            Asset = Resources.Load(mPath);

            State = ResState.Loaded;

            return Asset;
        }

        public override void LoadAsync()
        {
            State = ResState.Loading;
            var resRequest = Resources.LoadAsync(mPath);

            resRequest.completed += operation =>
            {
                Asset = resRequest.asset;

                State = ResState.Loaded;
            };
        }

        protected override void OnReleaseRes()
        {
            if (Asset is GameObject)
            {
                Asset = null;
                Resources.UnloadUnusedAssets();
            }
            else
            {
                Resources.UnloadAsset(Asset);
            }

            ResMgr.Instance.SharedLoadedReses.Remove(this);

            Asset = null;
        }

    }
}