
using UnityEngine;

namespace ZCode
{
    public class SimpleRCExample : MonoBehaviour
    {
        public class Light
        {
            public void Open()
            {
                Debug.Log("灯打开了");
            }

            public void Close()
            {
                Debug.Log("灯关闭了");
            }
        }

        public class Room:SimpleRC
        {
            Light mLight = new Light();

            public void EnterPeople()
            {
                if (RefCount == 0)
                {
                    mLight.Open();
                }
                Retain();
                Debug.LogFormat("一个人进入了房间，还有{0}个人", RefCount);
            }

            public void LeavePeople()
            {
                Release();
                Debug.LogFormat("一个人离开了房间，还有{0}个人", RefCount);
            }

            protected override void OnZeroRef()
            {
                mLight.Close();
            }
        }

#if UNITY_EDITOR
        [UnityEditor.MenuItem("ZCode/Examples/22.SimpleRCExample", false, 22)]
        static void MenuClicked()
        {
            Room room = new Room();

            room.EnterPeople();
            room.EnterPeople();
            room.EnterPeople();

            room.LeavePeople();
            room.LeavePeople();
            room.LeavePeople();

            room.EnterPeople();
        }

#endif
        // Use this for initialization
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public class Singleton<T> where T : Singleton<T>
        {
            //T t = new T();
        }

        public class B :Singleton<B>
        {

        }

        public class C : Singleton<B>
        {

        }
    }
}