using System;
using UnityEngine;

namespace QCode
{
    public class AssetBundleRes : Res
    {
        private ResLoader mResLoader = new ResLoader();
         
        private string mPath;

        public AssetBundleRes(string assetName)
        {
            mPath = ResKitUtil.FullPathForAssetBundle(assetName);

            Name = assetName;

            State = ResState.Waiting;
        }
        public AssetBundle AssetBundle
        {
            get { return Asset as AssetBundle; }
            set { Asset = value; }
        }

        private void LoadDependencyBundleAsync(Action onAllLoaded)
        {
            int loadedCount = 0;

            var dependencyBundleNames = ResData.Instance.GetDirectDependencies(Name);

            if(dependencyBundleNames.Length==0)
            {
                onAllLoaded();
            }

            foreach (var dependencyBundleName in dependencyBundleNames)
            {
                mResLoader.LoadAsync<AssetBundle>(dependencyBundleName,
                    dependBundle =>
                    {
                        loadedCount++;
                        if (loadedCount == dependencyBundleNames.Length)
                        {
                            onAllLoaded();
                        }
                    });
            }
        }

        public override void LoadAsync()
        {
            State = ResState.Loading;

            LoadDependencyBundleAsync(() =>
            {
                if (ResMgr.IsSimulationModeLogic)
                {
                    State = ResState.Loaded;
                }
                else
                {
                    var resRequest = AssetBundle.LoadFromFileAsync(mPath);

                    resRequest.completed += operation =>
                    {
                        AssetBundle = resRequest.assetBundle;

                        State = ResState.Loaded;
                    };
                }
            });

            
        }

        public override bool LoadSync()
        {
            State = ResState.Loading;

            var dependencyBundleNames = ResData.Instance.GetDirectDependencies(Name);

            foreach (var dependencyBundleName in dependencyBundleNames)
            {
                mResLoader.LoadSync<AssetBundle>(dependencyBundleName);
            }

            if (!ResMgr.IsSimulationModeLogic)
            {
                AssetBundle = AssetBundle.LoadFromFile(mPath);
            }

            State = ResState.Loaded;

            return AssetBundle;
        }

        protected override void OnReleaseRes()
        {
            if (AssetBundle != null)
            {
                AssetBundle.Unload(true);
                AssetBundle = null;
            }

            ResMgr.Instance.SharedLoadedReses.Remove(this);
        }
    }
}