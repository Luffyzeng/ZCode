using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZCode
{
    public class FrameworkExample : MonoBehaviourSimplify
    {
#if UNITY_EDITOR
        [UnityEditor.MenuItem("ZFramework/Examples/7.框架示例", false, 7)]
        static void MenuClicked()
        {
            UnityEditor.EditorApplication.isPlaying = true;
            new GameObject("FrameworkExample").AddComponent<FrameworkExample>();
        }
#endif

        void Awake()
        {
            RegisterMsg("Do", DoSomething);
            RegisterMsg("Do", DoSomething);
            RegisterMsg("Do1", _=> { });
            RegisterMsg("Do1", _ => { });
            RegisterMsg("Do1", _ => { });

            RegisterMsg("OK", data =>
            {
                Debug.Log(data);
                UnRegisterMsg("OK");
            });
        }

        IEnumerator Start()
        {
            Send("OK", "hello");
            Send("OK", "hello");

            MsgDispatcher.Send("Do", "hello");
            yield return new WaitForSeconds(1.0f);
            MsgDispatcher.Send("Do", "hello1");

        }

        private void DoSomething(object data)
        {
            Debug.LogFormat("Received Do Msg:{0}", data);
        }

        protected override void OnBeforeDestory()
        {
            
        }
    }
}