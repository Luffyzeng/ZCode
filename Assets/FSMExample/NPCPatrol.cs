using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QCode.FSM;

public class NPCPatrol : FSMState
{
    private Transform[] mPoints;
    private Transform mPlayer;
    private FSMSystem fsm;
    private int index = 0;
    public NPCPatrol(Transform[] path,Transform player,FSMSystem fSM)
    {
        mPoints = path;
        mPlayer = player;
        this.fsm = fSM;
        mStateID = StateID.Patrol;
    }
    public override void Act(GameObject npc)
    {
        npc.transform.LookAt(mPoints[index]);
        npc.transform.Translate(Vector3.forward * 5 * Time.deltaTime);
        if (Vector3.Distance(npc.transform.position, mPoints[index].position)<1)
        {
            index++;
            index %= mPoints.Length;
        }
    }

    public override void Reason(GameObject npc)
    {
        if(Vector3.Distance(npc.transform.position,mPlayer.transform.position)<2)
        {
            fsm.PerformTransition(Transition.SeePlayer);
        }
        
    }
}
