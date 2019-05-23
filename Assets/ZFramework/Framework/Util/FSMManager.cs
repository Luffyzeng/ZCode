
using UnityEngine;

namespace ZFramework
{
    public class StateBase
    {
        public virtual void OnEnter()
        {

        }

        public virtual void OnStay()
        {

        }

        public virtual void OnExit()
        {

        }
    }
    public class FSMManager : MonoBehaviour
    {

        StateBase[] allStates;

        //表示当前有多少个动画状态
        sbyte stateCount = -1;

        //表示当前的动画状态时什么
        sbyte curStateIndex = -1;
        
        public FSMManager(sbyte stateCount)
        {
            Initial(stateCount);
        }

        void Initial(sbyte stateCount)
        {
            if (stateCount < 0)
            {
                Debug.LogError("stateCount 不能为<0");
            }
            allStates = new StateBase[stateCount];
        }

        public void AddState(StateBase state)
        {
            if (stateCount > allStates.Length)
            {
                Debug.LogError("动画状态数组已满");
                return;
            }

            stateCount++;
            allStates[stateCount] = state;
        }

        public void ChangeState(sbyte stateIndex)
        {
            if (curStateIndex != -1)
                allStates[curStateIndex].OnExit();

            curStateIndex = stateIndex;

            allStates[stateIndex].OnEnter();
        }

        public void Stay()
        {
            if (curStateIndex != -1)
            {
                allStates[curStateIndex].OnStay();
            }
        }
    }
}