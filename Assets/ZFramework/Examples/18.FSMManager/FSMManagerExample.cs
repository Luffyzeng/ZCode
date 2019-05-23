using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZCode
{
    
    public class FSMManagerExample : MonoBehaviour
    {
        enum State
        {
            Idle,
            Walk,
            Run,
            Max
        } 
        private class Idle:StateBase
        {
            public override void OnEnter()
            {
                Debug.Log("Idle");
            }
        }
        private class Walk : StateBase
        {
            public override void OnEnter()
            {
                Debug.Log("Walk");
            }
        }
        private class Run : StateBase
        {
            public override void OnEnter()
            {
                Debug.Log("Run");
            }
        }

        FSMManager fsmManager;
        // Use this for initialization
        void Start()
        {
            fsmManager = new FSMManager((sbyte)State.Max);

            Idle idle = new Idle();
            fsmManager.AddState(idle);

            Walk walk = new Walk();
            fsmManager.AddState(walk);

            Run run = new Run();
            fsmManager.AddState(run);
        }

        // Update is called once per frame
        void Update()
        {
            fsmManager.Stay();
            if (Input.GetKeyDown(KeyCode.Q))
            {
                fsmManager.ChangeState((sbyte)State.Idle);
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                fsmManager.ChangeState((sbyte)State.Walk);
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                fsmManager.ChangeState((sbyte)State.Run);
            }
        }

#if UNITY_EDITOR
        [UnityEditor.MenuItem("ZFramework/Examples/18.FSMManager", false, 18)]
        static void MenuClicked()
        {
            UnityEditor.EditorApplication.isPlaying = true;
            new GameObject("FSMManagerExample").AddComponent<FSMManagerExample>();
        }

#endif
    }
}