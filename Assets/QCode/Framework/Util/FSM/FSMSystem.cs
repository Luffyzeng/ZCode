using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QCode.FSM
{
    public class FSMSystem
    {
        private List<FSMState> mStates = new List<FSMState>();
        private StateID mCurStateID;
        public StateID CurStateID { get { return mCurStateID; } }

        private FSMState mCurState;
        public FSMState CurState { get { return mCurState; } }
        
        public void AddState(FSMState s)
        {
            if (s==null)
            {
                Debug.LogError("FSM Error: Null reference is not allowed");
            }
            if (mStates.Count == 0)
            {
                mStates.Add(s);
                mCurState = s;
                mCurStateID = s.ID;
                return;
            }
            foreach (var state in mStates)
            {
                if (state.ID == s.ID)
                {
                    Debug.LogError("FSM Error: State " + s.ToString() + " has already been added");
                    return;
                }
            }

            mStates.Add(s);
        }
        public void DeleteState(StateID id)
        {
            if (id == StateID.NullStateID)
            {
                Debug.LogError("FSM Error: NullStateID is not allowed");
                return;
            }
            foreach (var state in mStates)
            {
                if (state.ID == id)
                {
                    mStates.Remove(state);
                    return;
                }
            }
            Debug.LogError("FSM Error: Not exists in list");
        }
        public void PerformTransition(Transition transition)
        {
            if (transition == Transition.NullTransition)
            {
                Debug.LogError("FSM ERROR: NullTransition is not allowed");
                return;
            }

            StateID id = mCurState.GetOutputState(transition);
            if (id == StateID.NullStateID)
            {
                Debug.LogError("FSM Error: 当前的 Transition " + transition.ToString() + " 没有对应的StateID");
                return;
            }
            mCurStateID = id;
            foreach (var state in mStates)
            {
                if (state.ID == mCurStateID)
                {
                    mCurState.DoBeforeLeaving();
                    mCurState = state;
                    mCurState.DoBeforeEntering();
                    break;
                }
            }
        }
    }
}