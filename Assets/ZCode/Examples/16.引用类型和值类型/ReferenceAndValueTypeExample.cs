using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZCode
{
    
    public class ReferenceAndValueTypeExample
    {
#if UNITY_EDITOR
        [UnityEditor.MenuItem("ZCode/Examples/16.引用类型和值类型",false,16)]
        static void MenuClicked()
        {
            Go();
        }
#endif

        private static void Go()
        {
            Thing x = new Animal();
            SwitchClass(x);
            Debug.Log("x is Aniaml  :   " + (x is Animal).ToString());
            Debug.Log("x is Vegetable  :   " + (x is Vegetable).ToString());
            SwitchClassByRef(ref x);
            Debug.Log("x is Aniaml  :   " + (x is Animal).ToString());
            Debug.Log("x is Vegetable  :   " + (x is Vegetable).ToString());

            MyInt m = new MyInt();
            DoSomething(m);
            Debug.Log("m.MyValue is  :  " + m.MyValue);
        }

        private static void DoSomething(MyInt myInt)
        {
            myInt.MyValue = 123;
        }

        private static void SwitchClass(Thing pValue)
        {
            pValue = new Vegetable();
        }

        private static void SwitchClassByRef(ref Thing pValue)
        {
            pValue = new Vegetable();
        }

        private class MyInt
        {
            public int MyValue = 0;
        }

        private class Thing { }
        private class Animal : Thing
        {
            public int weight=0;
        }
        private class Vegetable : Thing
        {
            public int length=0;
        }

    }

}