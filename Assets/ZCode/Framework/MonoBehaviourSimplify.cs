using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZCode
{
    public abstract partial class MonoBehaviourSimplify : MonoBehaviour
    {
        #region 定时功能
        public void Delay(float seconds, Action onFinished)
        {
            StartCoroutine(DelayCoroutine(seconds, onFinished));
        }

        private IEnumerator DelayCoroutine(float seconds, Action onFinished)
        {
            yield return new WaitForSeconds(seconds);
            onFinished();
        }
        #endregion


        #region 消息封装

        List<MsgRecord> mMsgRecorder = new List<MsgRecord>();
        class MsgRecord
        {
            private static Stack<MsgRecord> mMsgRecordPool = new Stack<MsgRecord>();
            public static MsgRecord Allocate(string msgName, Action<object> onMsgReceived)
            {
                MsgRecord retMsgRecord = null;

                if (mMsgRecordPool.Count > 0)
                {
                    retMsgRecord = mMsgRecordPool.Pop();
                }
                else
                {
                    retMsgRecord = new MsgRecord();
                    retMsgRecord.Name = msgName;
                    retMsgRecord.OnMsgReceived = onMsgReceived;
                }

                return retMsgRecord;
            }
            public void Recycle()
            {
                Name = null;
                OnMsgReceived = null;
                mMsgRecordPool.Push(this);
            }
            public string Name;
            public Action<object> OnMsgReceived;
        }

        protected void RegisterMsg(string msgName, Action<object> onMsgReceived)
        {
            MsgDispatcher.Register(msgName, onMsgReceived);

            mMsgRecorder.Add(MsgRecord.Allocate(msgName, onMsgReceived));
        }

        protected void UnRegisterMsg(string msgName)
        {
            var selectedRecords = mMsgRecorder.FindAll(recorder => recorder.Name == msgName);
            selectedRecords.ForEach(selectedRecord =>
            {
                MsgDispatcher.UnRegister(msgName, selectedRecord.OnMsgReceived);
                mMsgRecorder.Remove(selectedRecord);
                selectedRecord.Recycle();
            });
            selectedRecords.Clear();
        }

        protected void UnRegisterMsg(string msgName, Action<object> onMsgReceived)
        {
            var selectedRecords = mMsgRecorder.FindAll(recorder => recorder.Name == msgName &&
            recorder.OnMsgReceived == onMsgReceived);
            selectedRecords.ForEach(selectedRecord =>
            {
                MsgDispatcher.UnRegister(selectedRecord.Name, selectedRecord.OnMsgReceived);
                mMsgRecorder.Remove(selectedRecord);
                selectedRecord.Recycle();
            });
            selectedRecords.Clear();
        }

        protected void Send(string msgName, object data)
        {
            MsgDispatcher.Send(msgName, data);
        }

        private void OnDestory()
        {
            OnBeforeDestory();
            foreach (var msgRecorder in mMsgRecorder)
            {
                MsgDispatcher.UnRegister(msgRecorder.Name, msgRecorder.OnMsgReceived);
                msgRecorder.Recycle();
            }
            mMsgRecorder.Clear();
        }

        protected abstract void OnBeforeDestory();
        #endregion
    }
}