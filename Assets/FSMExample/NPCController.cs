using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QCode.FSM;

public class NPCController : MonoBehaviour {

    private FSMSystem fsm;
    private Transform mPlayer;
    private Transform[] mPath;
	// Use this for initialization
	void Start () {
        mPath = GameObject.Find("Path").GetComponentsInChildren<Transform>();
        mPlayer = GameObject.Find("Player").transform;
        InitFSM();
    }

    void InitFSM()
    {
        fsm = new FSMSystem();

        NPCPatrol patrol = new NPCPatrol(mPath,mPlayer,fsm);
        patrol.AddTrantision(Transition.SeePlayer, StateID.Chase);
        fsm.AddState(patrol);

        NPCChase chase = new NPCChase(mPlayer, fsm);
        chase.AddTrantision(Transition.LostPlayer, StateID.Patrol);
        fsm.AddState(chase);
    }
	
	// Update is called once per frame
	void Update () {

        fsm.CurState.Act(this.gameObject);
        fsm.CurState.Reason(this.gameObject);
	}
}
