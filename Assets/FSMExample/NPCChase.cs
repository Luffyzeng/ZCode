using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QCode.FSM;
public class NPCChase : FSMState
{
    private Transform mPlayer;
    private FSMSystem fsm;
    public NPCChase(Transform player,FSMSystem fSM)
    {
        mPlayer = player;
        fsm = fSM;
        mStateID = StateID.Chase;
    }
    public override void Act(GameObject npc)
    {
        npc.transform.LookAt(mPlayer);
        npc.transform.Translate(Vector3.forward * 5 * Time.deltaTime);
    }

    public override void Reason(GameObject npc)
    {
        if (Vector3.Distance(npc.transform.position, mPlayer.position) > 6)
        {
            fsm.PerformTransition(Transition.LostPlayer);
        }
    }
}
