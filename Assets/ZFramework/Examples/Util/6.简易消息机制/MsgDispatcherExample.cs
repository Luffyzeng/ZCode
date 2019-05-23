
using UnityEngine;

namespace ZFramework
{
    public class MsgDispatcherExample
    {

#if UNITY_EDITOR
        [UnityEditor.MenuItem("ZFramework/Examples/6.简易消息机制", false, 6)]
        static void MenuClicked()
        {
            MsgDispatcher.UnRegisterAll("消息1");
            MsgDispatcher.Register("消息1", OnMsgReceived);
            MsgDispatcher.Register("消息1", OnMsgReceived);
            MsgDispatcher.Send("消息1", "Hello World");
            MsgDispatcher.UnRegister("消息1", OnMsgReceived);
            MsgDispatcher.Send("消息1", "hello");
        }
#endif

        static void OnMsgReceived(object data)
        {
            Debug.LogFormat("消息1：{0}", data);
        }

    }
}