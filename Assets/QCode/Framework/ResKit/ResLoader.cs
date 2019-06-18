
using System;
using System.Collections.Generic;
using UnityEngine;

namespace QCode
{
    public class ResLoader 
    {
        public T LoadSync<T>(string assetName) where T : UnityEngine.Object
        {
            return DoLoadSync<T>(assetName);
        }

        public T LoadSync<T>(string ownerBundleName, string assetName) where T : UnityEngine.Object
        {
            return DoLoadSync<T>(assetName, ownerBundleName);
        }

        public void LoadAsync<T>(string assetName, Action<T> onLoaded) where T : UnityEngine.Object
        {
            DoLoadAsync(assetName, null, onLoaded);
        }

        public void LoadAsync<T>(string ownerBundleName, string assetName, Action<T> onLoaded) where T : UnityEngine.Object
        {
            DoLoadAsync(assetName, ownerBundleName, onLoaded);
        }

        public void ReleaseAll()
        {
            mResRecord.ForEach(loadedRes =>
            {
                loadedRes.Release();
            });

            mResRecord.Clear();
        }

        #region Private

        private T DoLoadSync<T>(string assetName, string ownerBundleName = null) where T : UnityEngine.Object
        {
            //result asset
            var res = GetOrCreateRes(assetName);

            if (res != null)
            {
                if (res.State == ResState.Loading)
                {
                    throw new System.Exception(string.Format("请不要在异步加载资源 {0} 时，进行{0}的同步加载", res.Name));
                }
                else if (res.State == ResState.Loaded)
                {
                    return res.Asset as T;
                }
            }

            res = CreateRes(assetName, ownerBundleName);
            res.LoadSync();

            return res.Asset as T;
        }

        private void DoLoadAsync<T>(string assetName, string ownerBundleName, Action<T> onLoaded) where T : UnityEngine.Object
        {
            var res = GetOrCreateRes(assetName);

            Action<Res> onResLoaded = null;

            onResLoaded = loadedRes =>
            {
                onLoaded(loadedRes.Asset as T);

                res.UnRegisterOnLoadedEvent(onResLoaded);
            };

            if (res != null)
            {
                if (res.State == ResState.Loading)
                {
                    res.RegisterOnLoadedEvent(onResLoaded);
                }
                else if (res.State == ResState.Loaded)
                {
                    onLoaded(res.Asset as T);
                }

                return;
            }

            res = CreateRes(assetName, ownerBundleName);

            res.RegisterOnLoadedEvent(onResLoaded);

            res.LoadAsync();
        }

        private List<Res> mResRecord = new List<Res>();

        private Res GetResFromRecord(string assetName)
        {
            return mResRecord.Find(loadedRes => loadedRes.Name == assetName);
        }

        private Res GetResFromMgr(string assetName)
        {
            return ResMgr.Instance.SharedLoadedReses.Find(loadedRes => loadedRes.Name == assetName);
        }

        private void AddRes2Record(Res res)
        {
            mResRecord.Add(res);
            res.Retain();
        }

        private Res CreateRes(string assetName,string assetBundleName=null)
        {
            Res res = null;

            res = ResFactory.CreateRes(assetName, assetBundleName);

            AddRes2Record(res);
            ResMgr.Instance.SharedLoadedReses.Add(res);
            return res;
        }

        private Res GetOrCreateRes(string assetName)
        {
            //查询当前资源池
            var res = GetResFromRecord(assetName);
            if (res != null)
            {
                return res;
            }

            //查询全局资源池
            res = GetResFromMgr(assetName);
            if (res != null)
            {
                AddRes2Record(res);
                return res;
            }

            return res;
        }
        #endregion
    }
}