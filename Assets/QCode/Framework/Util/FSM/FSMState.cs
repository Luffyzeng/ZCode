using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QCode.FSM
{
    public enum Transition
    {
        NullTransition=0,
        SeePlayer,
        LostPlayer
    }

    public enum StateID
    {
        NullStateID=0,
        Patrol,
        Chase
    }

    public abstract class FSMState
    {
        protected StateID mStateID;
        public StateID ID { get { return mStateID; } }
        protected Dictionary<Transition, StateID> map = new Dictionary<Transition, StateID>();

        public void AddTrantision(Transition transition,StateID stateID)
        {
            if (transition == Transition.NullTransition)
            {
                Debug.LogError("FSMState Error: transition 不允许为空");
                return;
            }
            if (stateID == StateID.NullStateID)
            {
                Debug.LogError("FSMState Error: stateID 不允许为空");
                return;
            }
            if (map.ContainsKey(transition))
            {
                Debug.Log("FSMState Error: transition 已经存在map中");
                return;
            }

            map.Add(transition, stateID);
        }

        public void DeleteTransition(Transition transition)
        {
            if (transition == Transition.NullTransition)
            {
                Debug.LogError("FSMState Error: NullTransition is not allowed");
                return;
            }
            if (map.ContainsKey(transition))
            {
                map.Remove(transition);
                return;
            }

            Debug.LogError("FSMState Error: Transition " + transition.ToString() + "  not exists in map");
        }

        public StateID GetOutputState(Transition transition)
        {
            if (map.ContainsKey(transition))
            {
                return map[transition];
            }
            return StateID.NullStateID;
        }

        public virtual void DoBeforeEntering() { }
        public virtual void DoBeforeLeaving() { }
        public abstract void Act(GameObject npc);
        public abstract void Reason(GameObject npc);      //判断转换条件
    }
}