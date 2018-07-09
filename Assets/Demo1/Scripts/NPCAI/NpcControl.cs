using UnityEngine;
using System.Collections;

public class NpcControl : MonoBehaviour {

    private FSMSystem fsm;
    private GameObject player;
    public Transform[] waypoints;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        InitFSM();
    }
    void InitFSM()
    {
        fsm = new FSMSystem();

        PatrolState patrolState = new PatrolState(waypoints, this.gameObject, player);
        patrolState.AddTransition(Transition.SawPlayer,StateID.Chase);

        ChaseState chaseState = new ChaseState(this.gameObject,player);
        chaseState.AddTransition(Transition.LostPlayer, StateID.Patrol);

        fsm.AddState(patrolState);
        fsm.AddState(chaseState);

        fsm.Start(StateID.Patrol);
    }
    void Update()
    {
        fsm.CurrentState.DoUpdate();
    }
}
