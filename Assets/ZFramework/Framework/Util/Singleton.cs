using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace ZFramework
{
    public abstract class Singleton<T> where T:Singleton<T>
    {
        protected static T mInstance = null;

        protected Singleton()
        {

        }

        public static T Instance
        {
            get
            {
                if (mInstance==null)
                {
                    //先获取所有非public的构造方法
                    var ctors = typeof(T).GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic);
                    //从ctors中获取无参的构造方法
                    var ctor = Array.Find(ctors, c => c.GetParameters().Length==0);
                    if (ctor == null)
                    {
                        throw new Exception("Non-Public ctor() not found");
                    }
                    mInstance = ctor.Invoke(null) as T;
                }
                return mInstance;
            }
        }
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}